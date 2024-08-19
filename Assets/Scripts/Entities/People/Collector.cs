using System;
using OldSystem.DataScriptableObjects.EntityDataScriptableObjects;
using Pathfinding;
using UnityEngine;

namespace Entities.People
{
    public class Collector : MonoBehaviour
    {
        #region Data and Components

        public MinionData data;
        
        private Rigidbody2D _rb;

        private Animator _anim;

        [NonSerialized] public GameManager.GameManager GameManager;

        #endregion

        #region State Parameters

        private State _currentState;

        private float _startTime;

        private bool _stayHome;

        private enum State
        {
            GoMining,
            WorkInMines,
            GoHome,
            WorkAtHome
        }

        #endregion

        #region Pathfinding Parameters

        private Seeker _seeker;

        private Path _path;

        private int _currentWayPoint;

        private bool _reachedDestination = false;

        [NonSerialized] public Transform[] Targets;

        #endregion
        
        #region Unity Callback Functions

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _seeker = GetComponent<Seeker>();
            _anim = GetComponent<Animator>();
            
            SwitchState(State.GoMining);
            
            GameManager.OnDawn += HandleOnDawn;
            GameManager.OnDusk += HandleOnDusk;
        }

        private void OnDisable()
        {
            GameManager.OnDawn -= HandleOnDawn;
            GameManager.OnDusk -= HandleOnDusk;
        }

        private void Update()
        {
            switch (_currentState)
            {
                case State.GoMining:
                    UpdateGoMining();
                    break;
                case State.WorkInMines:
                    UpdateWorkInMines();
                    break;
                case State.GoHome:
                    UpdateGoHome();
                    break;
                case State.WorkAtHome:
                    UpdateWorkAtHome();
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

            if (_path.vectorPath.Count <= _currentWayPoint + 1)
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
                case State.GoMining:
                    ExitGoMining();
                    break;
                case State.WorkInMines:
                    ExitWorkInMines();
                    break;
                case State.GoHome:
                    ExitGoHome();
                    break;
                case State.WorkAtHome:
                    ExitWorkAtHome();
                    break;
            }
            
            switch (state)
            {
                case State.GoMining:
                    EnterGoMining();
                    break;
                case State.WorkInMines:
                    EnterWorkInMines();
                    break;
                case State.GoHome:
                    EnterGoHome();
                    break;
                case State.WorkAtHome:
                    EnterWorkAtHome();
                    break;
            }

            _currentState = state;
        }

        #region GoMining State

        private void EnterGoMining()
        {
            if (Targets.Length < 2) return;
            
            FindPath(Targets[0]);
            
            _anim.SetBool("move", true);
        }

        private void UpdateGoMining()
        {
            _rb.velocity = FindDirection() * data.moveSpeed;
            
            if (_reachedDestination) SwitchState(State.WorkInMines);
        }

        private void ExitGoMining()
        {
            _reachedDestination = false;
            
            _anim.SetBool("move", false);
        }

        #endregion

        #region WorkInMines State

        private void EnterWorkInMines()
        {
            _startTime = Time.time;

            _rb.velocity = Vector2.zero;
            
            _anim.SetBool("mine", true);
        }

        private void UpdateWorkInMines()
        {
            if (Time.time > _startTime + data.mineTime) SwitchState(State.GoHome);
        }

        private void ExitWorkInMines()
        {
            _anim.SetBool("mine", false);
        }

        #endregion

        #region GoHome State

        private void EnterGoHome()
        {
            if (Targets.Length < 2) return;
            
            FindPath(Targets[1]);
            
            _anim.SetBool("move", true);
        }

        private void UpdateGoHome()
        {
            _rb.velocity = FindDirection() * data.moveSpeed;
            
            if (_reachedDestination) SwitchState(State.WorkAtHome);
        }

        private void ExitGoHome()
        {
            _reachedDestination = false;
            
            _anim.SetBool("move", false);
        }

        #endregion

        #region WorkAtHome State

        private void EnterWorkAtHome()
        {
            _startTime = Time.time;
            
            _rb.velocity = Vector2.zero;
            
            _anim.SetBool("empty", true);
        }

        private void UpdateWorkAtHome()
        {
            if (Time.time > _startTime + data.mineTime && !_stayHome) SwitchState(State.GoMining);
        }

        private void ExitWorkAtHome()
        {
            _anim.SetBool("empty", false);
        }

        #endregion

        #endregion

        #region Handler Functions

        private void HandleOnDawn()
        {
            SwitchState(State.GoMining);

            _stayHome = false;
        }

        private void HandleOnDusk()
        {
            SwitchState(State.GoHome);

            _stayHome = true;
        }

        #endregion
    }
}