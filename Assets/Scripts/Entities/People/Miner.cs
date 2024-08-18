using System;
using System.Linq;
using OldSystem.DataScriptableObjects;
using OldSystem.DataScriptableObjects.EntityDataScriptableObjects;
using Pathfinding;
using UnityEngine;
using UnityEngine.Serialization;

namespace Entities.People
{
    public class Miner : MonoBehaviour
    {
        #region Data and Components

        public MinionData data;
        
        private Rigidbody2D _rb;

        #endregion

        #region State Parameters

        private State _currentState;

        private float _startTime;

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

        private Transform target1;

        private Transform target2;

        #endregion
        
        #region Unity Callback Functions

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _seeker = GetComponent<Seeker>();
            
            SwitchState(State.GoHome);

            target1 = GameObject.FindGameObjectWithTag("Finish").transform;
            target2 = GameObject.FindGameObjectWithTag("Respawn").transform;
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
                    UpdateWorkInMines();
                    break;
            }
        }

        #endregion

        #region Pathfinding

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

        private void FindPath(Transform target)
        {
            _seeker.StartPath(transform.position, target.position, OnPathComplete);
        }

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
            _startTime = Time.time;
            
            FindPath(target1);
        }

        private void UpdateGoMining()
        {
            _rb.velocity = FindDirection();
            
            if (Time.time > _startTime + data.transferTime) SwitchState(State.GoHome);
        }

        private void ExitGoMining()
        {
            
        }

        #endregion

        #region WorkInMines State

        private void EnterWorkInMines()
        {
            
        }

        private void UpdateWorkInMines()
        {
            
        }

        private void ExitWorkInMines()
        {
            
        }

        #endregion

        #region GoHome State

        private void EnterGoHome()
        {
            _startTime = Time.time;
        }

        private void UpdateGoHome()
        {
            _rb.velocity = Vector2.left;
            
            if (Time.time > _startTime + data.transferTime) SwitchState(State.GoMining);
        }

        private void ExitGoHome()
        {
            
        }

        #endregion

        #region WorkAtHome State

        private void EnterWorkAtHome()
        {
            
        }

        private void UpdateWorkAtHome()
        {
            
        }

        private void ExitWorkAtHome()
        {
            
        }

        #endregion

        #endregion
    }
}