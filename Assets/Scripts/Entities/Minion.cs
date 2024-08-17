using CoreSystem.CoreComponents;
using UnityEngine;

namespace Entities
{
    public class Minion : Entity
    {
        #region Core Components

        public Movement Movement => _movement ??= Core.GetCoreComponent<Movement>();
        private Movement _movement;

        public PathFinding Pathfinding => _pathfinding ??= Core.GetCoreComponent<PathFinding>();
        private PathFinding _pathfinding;

        #endregion

        #region Other Components

        public Animator anim { get; private set; }

        #endregion
    }
}