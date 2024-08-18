using System;
using System.Linq;
using OldSystem.DataScriptableObjects;
using OldSystem.DataScriptableObjects.EntityDataScriptableObjects;
using Pathfinding;
using UnityEngine;

namespace Entities.People
{
    public class Miner : MonoBehaviour
    {
        private Rigidbody2D _rb;

        public MinionData _data;

        private GameObject _gameManagerObject;
        private GameManager.GameManager _gameManager;

        #region State Parameters

        private bool _goMining;
        private bool _mine;
        private bool _goHome;
        private bool _transfer;

        private float _startTime;

        #endregion
        
        #region Pathfinding Parameters

        private Seeker _seeker;

        private Path _path;

        private int _currentWayPoint;
        
        private bool _reachedDestination = false;

        public Transform target1;
        public Transform target2;

        #endregion

        
        private enum State
        {
            GoMining,
            WorkInMines,
            GoHome,
            WorkAtHome
        }

        private State _currentState = State.GoHome;

        #region GoMining State

        private void EnterGoMining()
        {
            FindPath(target1);
        }

        private void UpdateGoMining()
        {
            _rb.velocity = FindDirection() * 10;
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
            FindPath(target2);
        }

        private void UpdateGoHome()
        {
            _rb.velocity = FindDirection() * 10;
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
        private void Awake()
        {
            _gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
            _gameManager = _gameManagerObject.GetComponent<GameManager.GameManager>();
            _gameManager.OnDawn += HandleOnDawn;
            _gameManager.OnDusk += HandleOnDusk;
        }

        private void OnDestroy()
        {
            _gameManager.OnDawn -= HandleOnDawn;
            _gameManager.OnDusk -= HandleOnDusk;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _seeker = GetComponent<Seeker>();
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

        private void HandleOnDawn()
        {
            SwitchState(State.GoMining);
        }

        private void HandleOnDusk()
        {
            SwitchState(State.GoHome);
        }

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
    }
}