using DataScriptableObjects;
using Entities;
using UnityEngine;

namespace StateMachine.Specific
{
    public class MinionState : State
    {
        protected Minion entity;
        private string animBoolName;
        
        public MinionState(Minion entity, StateData stateData, string animBoolName) : base(entity, stateData)
        {
            this.animBoolName = animBoolName;
            this.entity = entity;
        }

        public override void Enter()
        {
            base.Enter();
            
            // entity.anim.SetBool(animBoolName, true);
        }

        public override void Exit()
        {
            base.Exit();
            
            // entity.anim.SetBool(animBoolName, false);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            Debug.Log(animBoolName);
        }
    }
}