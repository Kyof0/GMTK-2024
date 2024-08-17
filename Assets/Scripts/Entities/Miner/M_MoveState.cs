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

            if (direction == Vector2.zero) StateMachine.ChangeState(entity.WaitState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            if(direction != Vector2.zero) entity.Movement.Move(stateData.movementSpeed, direction);
        }

        public override void DoChecks()
        {
            base.DoChecks();

            direction = entity.Pathfinding.direction;
        }
    }
}