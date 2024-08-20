using UnityEngine;

namespace OldSystem.DataScriptableObjects.EntityDataScriptableObjects
{
    [CreateAssetMenu(fileName = "EntityData", menuName = "Data/Entity Data/Warrior Data")]
    public class WarriorData : EntityData
    {
        public float moveSpeed;
        public float killTime;
        public float wanderPeriod;
    }
}