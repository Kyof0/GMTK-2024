using UnityEngine;

namespace OldSystem.DataScriptableObjects.EntityDataScriptableObjects
{
    [CreateAssetMenu(fileName = "EntityData", menuName = "Data/Entity Data/Wanderer Data")]
    public class WandererData : EntityData
    {
        public float moveSpeed;
        public float period;
    }
}