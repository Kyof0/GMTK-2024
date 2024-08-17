using DataScriptableObjects;
using Entities;
using UnityEngine;

namespace StateMachine
{
    public class State
    {
        #region Parameters

        protected readonly Entity Entity;
        protected readonly StateData StateData;
        protected FiniteStateMachine StateMachine;

        protected float startTime;

        #endregion
        
        public State(Entity entity, StateData stateData)
        {
            this.Entity = entity;
            this.StateData = stateData;
            this.StateMachine = entity.StateMachine;
        }

        #region Unity Callback Functions

        public virtual void Enter()
        {
            startTime = Time.time;
        }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks() { }

        public virtual void Exit() { }

        #endregion
    }
}