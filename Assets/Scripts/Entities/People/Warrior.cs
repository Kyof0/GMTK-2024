using System;
using System.Collections.Generic;
using System.Linq;
using OldSystem.DataScriptableObjects.EntityDataScriptableObjects;
using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Entities.People
{
    public class Warrior : MonoBehaviour
    {
        #region Data and Components

        public WarriorData data;
        
        private Rigidbody2D _rb;

        private Animator _anim;

        [NonSerialized] public GameManager.GameManager GameManager;

        #endregion

        #region State Parameters

        private enum State
        {
            Wander,
            Kill
        }

        private State _currentState;

        private float _startTime;

        private bool _move;

        private Vector2 _direction;

        #endregion

        #region Pathfinding Parameters

        private Seeker _seeker;

        private Path _path;

        private int _currentWayPoint;

        private bool _reachedDestination;

        [NonSerialized] public Transform[] Targets;

        private Transform _closestTarget;

        #endregion
        
        #region Unity Callback Functions

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _seeker = GetComponent<Seeker>();
            _anim = GetComponent<Animator>();
            
            SwitchState(State.Kill);
            
            GameManager.OnPeace += HandleOnPeace;
            GameManager.OnWar += HandleOnWar;
        }

        private void OnDisable()
        {
            GameManager.OnPeace -= HandleOnPeace;
            GameManager.OnWar -= HandleOnWar;
        }

        private void Update()
        {
            switch (_currentState)
            {
                case State.Wander:
                    UpdateWander();
                    break;
                case State.Kill:
                    UpdateKill();
                    break;
            }
        }

        #endregion

        #region Pathfinding

        /// <summary>
        /// Runs A* algorithm and saves the path in _path variable
        /// </summary>
        /// <param name="target"></param>
        private void FindPath(Transform target)
        {
            _seeker.StartPath(transform.position, target.position, OnPathComplete);
        }

        /// <summary>
        /// Uses the already generated path to return immediate direction to go
        /// </summary>
        /// <returns></returns>
        private Vector2 FindDirection()
        {
            if (_path == null || _path.vectorPath.Count <= _currentWayPoint + 1) return Vector2.zero;

            if (Vector2.Distance(transform.position, _path.vectorPath[_currentWayPoint + 1]) < 0.3f) 
                _currentWayPoint++;

            if (_path.vectorPath.Count <= _currentWayPoint + 2)
            {
                _reachedDestination = true;
                return Vector2.zero;
            }

            return (_path.vectorPath[_currentWayPoint + 1] - transform.position).normalized;
        }

        /// <summary>
        /// Helper function to FindPath function
        /// </summary>
        /// <param name="path"></param>
        private void OnPathComplete(Path path)
        {
            if (!path.error)
            {
                this._path = path;
                _currentWayPoint = 0;
            }
        }

        #endregion

        #region FSM
        
        private void SwitchState(State state)
        {
            switch (_currentState)
            {
                case State.Wander:
                    ExitWander();
                    break;
                case State.Kill:
                    ExitKill();
                    break;
            }
            
            switch (state)
            {
                case State.Wander:
                    EnterWander();
                    break;
                case State.Kill:
                    EnterKill();
                    break;
            }

            _currentState = state;
        }

        #region Wander State

        private void EnterWander() { }

        private void UpdateWander()
        {
            switch (_move)
            {
                case true:
                    _rb.velocity = _direction.normalized * data.moveSpeed;
                    break;
                case false:
                    _rb.velocity = Vector2.zero;
                
                    _direction.Set(Random.Range(-1,2), Random.Range(-1,2));
                    break;
            }

            _move = (Time.time % data.wanderPeriod > data.wanderPeriod / 2);
            
            _anim.SetBool("move", _move);
        }

        private void ExitWander() { }

        #endregion

        #region Kill State

        private void EnterKill()
        {
            if(Targets.Length == 0) SwitchState(State.Wander);
            
            _closestTarget = Targets[0];
            foreach (var target in Targets)
            {
                var dist = (transform.position - target.position).magnitude;
                if (dist < (transform.position - _closestTarget.position).magnitude) _closestTarget = target;
            }
        }

        private void UpdateKill()
        {
            if (_reachedDestination)
            {
                _startTime = Time.time;
                
                _closestTarget.gameObject.SetActive(false);
                HashSet<Transform> targetList = Targets.ToHashSet();
                targetList.Remove(_closestTarget);
                Targets = targetList.ToArray();

                _reachedDestination = false;
                
                SwitchState(State.Kill);
            }
            
            FindPath(_closestTarget);

            _rb.velocity = Time.time < _startTime + data.killTime ? Vector2.zero : FindDirection() * data.moveSpeed;
        }

        private void ExitKill() { }

        #endregion

        #endregion

        #region Handler Functions

        private void HandleOnPeace()
        {
            SwitchState(State.Wander);
        }

        private void HandleOnWar()
        {
            SwitchState(State.Kill);
        }

        #endregion
    }
}