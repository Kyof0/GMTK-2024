using System;
using CoreSystem;
using DataScriptableObjects;
using StateMachine;
using UnityEngine;

namespace Entities
{
    public class Entity : MonoBehaviour
    {
        // An entity can be any game object that we think should have a finite state machine (FSM). All other things serve
        // this FSM AI.
        
        #region Core Components

        // Here we have our core components. They share the function burden of the entity and introduce reusability to
        // our system.
        
        public Core Core => _core ??= GetComponentInChildren<Core>();
        private Core _core;

        #endregion

        #region Other Components

        // These are the basic parameters that any entity, a tribe or a member of a tribe, should need.

        public EntityData Data;

        public FiniteStateMachine StateMachine;

        #endregion

        #region Unity Callback Functions

        protected virtual void Awake()
        {
            StateMachine = new FiniteStateMachine();
        }

        protected virtual void Start() { }

        protected virtual void Update()
        {
            StateMachine.CurrentState.LogicUpdate();
            Core.LogicUpdate();
        }

        protected virtual void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
            Core.PhysicsUpdate();
        }

        protected virtual void OnDrawGizmos() { }

        protected virtual void OnDestroy() { }

        #endregion
    }
}