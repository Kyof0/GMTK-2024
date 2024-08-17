using OldSystem.DataScriptableObjects.StateDataScriptableObjects;
using OldSystem.StateMachine.EntitySpecific;
using UnityEngine;

namespace OldSystem.Entities.Soldier
{
    public class SMoveState : MinionState
    {
        private readonly Soldier entity;
        private readonly MoveStateData stateData;
        
        public SMoveState(Soldier entity, MoveStateData stateData, string animBoolName) : base(entity, stateData, animBoolName)
        {
            this.entity = entity;
            this.stateData = stateData;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (Time.time > startTime + stateData.moveTime) StateMachine.ChangeState(entity.WaitState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            entity.Movement.Move(stateData.movementSpeed, Vector2.down);
        }
    }
}