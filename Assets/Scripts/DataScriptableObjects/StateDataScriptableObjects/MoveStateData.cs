using UnityEngine;

namespace DataScriptableObjects.StateDataScriptableObjects
{
    [CreateAssetMenu(fileName = "StateData", menuName = "Data/State Data/Move State Data")]
    
    public class MoveStateData : StateData
    {
        public float movementSpeed;
        public float moveTime;
    }
}