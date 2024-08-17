using CoreSystem;
using DataScriptableObjects;
using DataScriptableObjects.StateDataScriptableObjects;
using StateMachine.Specific;
using UnityEngine;

namespace Entities.Miner
{
    public class MMoveState : MinionState
    {
        private Vector2 direction;
        private readonly MoveStateData stateData;
        private readonly Miner entity;
        public MMoveState(Miner entity, MoveStateData stateData, string animBoolName) : base(entity, stateData, animBoolName)
        {
            this.entity = entity;
            this.stateData = stateData;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time > stateData.moveTime + startTime) StateMachine.ChangeState(entity.WaitState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            entity.Movement.Move(stateData.movementSpeed, entity.Movement.facingDirection * Vector2.right);
        }

        public override void DoChecks()
        {
            base.DoChecks();

            direction = entity.Pathfinding.direction;
        }
    }
}