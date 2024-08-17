using System;
using Pathfinding;
using UnityEngine;

namespace Entities.People
{
    public class Miner : MonoBehaviour
    {
        private Rigidbody2D Rb;
        private Seeker _seeker;
        private Path _path;
        private Vector2 direction;
        private int _currentWayPoint;
        public Transform target;
        

        private void Start()
        {
            Rb = GetComponent<Rigidbody2D>();
            _seeker = GetComponent<Seeker>();
            FindPath();
            Debug.Log(direction);
        }

        private void Update()
        {
            Rb.velocity = direction;

            if (Vector2.Distance(transform.position, _path.vectorPath[_currentWayPoint]) > 0.3f) _currentWayPoint++;
            
            direction = (_path.vectorPath[_currentWayPoint] - transform.position).normalized;
        }
        
        public void FindPath()
        {
            _seeker.StartPath(transform.position, target.position, OnPathComplete);
            
            if (_path == null) return;

            direction = (_path.vectorPath[_currentWayPoint] - transform.position).normalized;
        }
        
        private void OnPathComplete(Path path)
        {
            if (!path.error)
            {
                this._path = path;
                _currentWayPoint = 0;
            }
        }
    }
}