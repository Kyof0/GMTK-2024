using UnityEngine;

namespace OldSystem.CoreSystem
{
    public class CoreComponent : MonoBehaviour
    {
        // A core component is a part of any entity's functionality. They do important jobs like movement, sensing,
        // pathfinding, etc. Hence we don't need to rewrite them for every entity.

        #region Parameters

        protected Core Core => _core ??= transform.GetComponent<Core>();
        private Core _core;

        #endregion

        #region Unity Callback Functions

        protected virtual void Awake()
        {
            if (Core) Core.AddComponent(this);
        }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() { }

        #endregion
    }
}