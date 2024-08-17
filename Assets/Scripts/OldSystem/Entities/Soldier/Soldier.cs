using OldSystem.DataScriptableObjects.StateDataScriptableObjects;

namespace OldSystem.Entities.Soldier
{
    public class Soldier : Minion
    {
        #region State Data

        public MoveStateData moveData;

        public WaitStateData waitData;

        #endregion

        #region State Variables

        public SMoveState MoveState { get; private set; }
        
        public SWaitState WaitState { get; private set; }

        #endregion
    }
}