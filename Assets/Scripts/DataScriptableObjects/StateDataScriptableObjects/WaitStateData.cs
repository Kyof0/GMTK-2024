using UnityEngine;

namespace DataScriptableObjects.StateDataScriptableObjects
{
    [CreateAssetMenu(fileName = "StateData", menuName = "Data/State Data/Wait State Data")]
    
    public class WaitStateData : StateData
    {
        public float waitingTime;
    }
}