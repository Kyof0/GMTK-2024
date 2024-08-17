using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using UnityEngine;

namespace CoreSystem
{
    public class Core : MonoBehaviour
    {
        #region Parameters 
        
        // Here we have references to the entity we are going to put this core on. Also we have a list to hold all our
        // core components.

        public GameObject Root => _root ??= transform.parent.gameObject;
        private GameObject _root;

        private Entity Entity => _entity ??= Root.GetComponent<Entity>();
        private Entity _entity;

        private List<CoreComponent> coreComponents = new();

        #endregion
        
        #region Unity Callback Functions
        
        // Here we have update functions that will be called by the entity monobehavior

        public void LogicUpdate()
        {
            foreach (var component in coreComponents) component.LogicUpdate();
        }

        public void PhysicsUpdate()
        {
            foreach (var component in coreComponents) component.PhysicsUpdate();
        }

        #endregion

        #region Functions

        // These additional funtions are for accessing the core components
        
        public void AddComponent(CoreComponent component)
        {
            if (!coreComponents.Contains(component)) coreComponents.Add(component);
        }

        public T GetCoreComponent<T>() where T : CoreComponent
        {
            var comp = coreComponents.OfType<T>().FirstOrDefault();

            if (comp != null) return comp;

            comp = GetComponentInChildren<T>();

            if (comp != null) return comp;

            Debug.Log($"{typeof(T)} not found on {transform.parent.name}");
            return null;
        }

        #endregion
    }
}