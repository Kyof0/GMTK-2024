using OldSystem.DataScriptableObjects.StateDataScriptableObjects;
using OldSystem.StateMachine.EntitySpecific;

namespace OldSystem.Entities.Soldier
{
    public class SWaitState : MinionState
    {
        private readonly Soldier entity;
        private readonly WaitStateData stateData;
        
        public SWaitState(Soldier entity, WaitStateData stateData, string animBoolName) : base(entity, stateData, animBoolName)
        {
            this.entity = entity;
            this.stateData = stateData;
        }
    }
}