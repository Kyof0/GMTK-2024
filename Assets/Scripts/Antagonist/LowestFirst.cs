//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// This AI class produces units that generate the resource that the enemy has the least of
//public class LowestFirst : AntagonistAI
//{
//  public float SpawnInterval = 2.0f;
//  private float lastSpawnTime;

//  // Start is called before the first frame update
//  void Start()
//  {

//  }

//  // Update is called once per frame
//  void Update()
//  {
//    Resource lowestResource = LowestResource();
//    MinionType nextMinion = GetMinionType(lowestResource);
//    if (CanSpawn())
//    {
//      // if (resources < GetMinionPrice(nextMinion)) return false;

//    }
//  }

//  bool CanSpawn() { throw new UnityException("Not implemented"); }

//  Resource LowestResource() { throw new UnityException(); }

//}
