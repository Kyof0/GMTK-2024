using System;
using Data;
using StateMachine;
using UnityEngine;

namespace Entities
{
    public class Entity : MonoBehaviour
    {
        #region Parameters

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
        }

        protected virtual void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }

        protected virtual void OnDrawGizmos() { }

        protected virtual void OnDestroy() { }

        #endregion
    }
}