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

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _seeker = GetComponent<Seeker>();
            
            FindPath(target1);

            _goMining = true;
            _mine = false;
            _goHome = false;
            _transfer = false;
        }

        private void Update()
        {
            var direction = FindDirection();

            if (_goMining && _reachedDestination)
            {
                _goMining = false;
                _mine = true;
                
                FindPath(target2);

                _reachedDestination = false;

                _startTime = Time.time;
            }

            if (_mine && Time.time > _data.mineTime + _startTime)
            {
                _mine = false;
                _goHome = true;
            }
            
            if (_goHome && _reachedDestination)
            {
                _goHome = false;
                _transfer = true;
                
                FindPath(target1);

                _reachedDestination = false;

                _startTime = Time.time;
            }

            if (_transfer && Time.time > _data.transferTime + _startTime)
            {
                _transfer = false;
                _goMining = true;
            }

            if (_goMining || _goHome) _rb.velocity = direction * _data.moveSpeed;
            else _rb.velocity = Vector2.zero;
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
    }
}