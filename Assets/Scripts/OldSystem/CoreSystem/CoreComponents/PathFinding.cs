using System;
using Pathfinding;
using UnityEngine;

namespace OldSystem.CoreSystem.CoreComponents
{
    public class PathFinding : CoreComponent
    {
        // This is the pathfinder component. Give it a target in the inspector window and it will return the direction
        // the entity must go.

        #region Parameters

        [NonSerialized] public Vector2 direction;

        public Transform Target;

        private Seeker Seeker => _seeker ??= GetComponent<Seeker>();
        private Seeker _seeker;

        private Path _path;

        private int _currentWayPoint;

        #endregion

        #region Unity Callback Functions

        private void Update()
        {
            if(_path == null) return;
            
            if (_path.vectorPath.Count <= _currentWayPoint + 1)
            {
                direction = Vector2.zero;
                return;
            }
            if ((_path.vectorPath[_currentWayPoint + 1] - transform.position).magnitude < 0.3f) _currentWayPoint++;
        }

        #endregion

        #region Functions

        public void FindPath()
        {
            Seeker.StartPath(transform.position, Target.position, OnPathComplete);
            
            if (_path == null) return;

            direction = (_path.vectorPath[_currentWayPoint + 1] - transform.position).normalized;
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