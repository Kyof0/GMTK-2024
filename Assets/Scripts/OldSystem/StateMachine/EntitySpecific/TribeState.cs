using OldSystem.DataScriptableObjects;
using OldSystem.Entities;

namespace OldSystem.StateMachine.EntitySpecific
{
    public class TribeState : State
    {
        // State of a tribe such as war or peace.
        
        public TribeState(Entity entity, StateData stateData) : base(entity, stateData)
        {
        }
    }
}