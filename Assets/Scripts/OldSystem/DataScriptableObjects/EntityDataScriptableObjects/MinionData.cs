﻿using UnityEngine;

namespace OldSystem.DataScriptableObjects.EntityDataScriptableObjects
{
    [CreateAssetMenu(fileName = "EntityData", menuName = "Data/Entity Data/Minion Data")]
    
    public class MinionData : EntityData
    {
        public float mineTime;
        public float transferTime;
        public float moveSpeed;
    }
}