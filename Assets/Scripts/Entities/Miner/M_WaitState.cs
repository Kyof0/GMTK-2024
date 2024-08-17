using DataScriptableObjects;
using DataScriptableObjects.StateDataScriptableObjects;
using StateMachine.Specific;
using UnityEngine;

namespace Entities.Miner
{
    public class MWaitState : MinionState
    {
        private readonly Miner entity;
        private readonly WaitStateData stateData;
        public MWaitState(Miner entity, WaitStateData stateData, string animBoolName) : base(entity, stateData, animBoolName)
        {
            this.entity = entity;
            this.stateData = stateData;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (Time.time > startTime + stateData.waitingTime) StateMachine.ChangeState(entity.MoveState);
        }
    }
}