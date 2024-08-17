using DataScriptableObjects;
using DataScriptableObjects.StateDataScriptableObjects;

namespace Entities.Miner
{
    public class Miner: Minion
    {
        #region State Data

        public MoveStateData moveData;

        public WaitStateData waitData;

        #endregion

        #region State Variables

        public MMoveState MoveState { get; private set; }
        public MWaitState WaitState { get; private set; }

        #endregion

        #region Unity Callback Functions

        protected override void Awake()
        {
            base.Awake();

            MoveState = new MMoveState(this, moveData, "move");
            WaitState = new MWaitState(this, waitData, "wait");
        }

        protected override void Start()
        {
            base.Start();
            
            StateMachine.Initialize(MoveState);
        }

        #endregion
    }
}