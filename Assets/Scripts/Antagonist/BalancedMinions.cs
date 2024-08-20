//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BalancedAntagonist : AntagonistAI
//{

//  private MinionType nextMinion = 0;
//  private int minionTypeCount = Enum.GetValues(typeof(MinionType)).Length;

//  public float SpawnInterval = 2.0f;
//  private float lastSpawnTime; 

//  // Start is called before the first frame update
//  void Start()
//  {

//  }

//  // Update is called once per frame
//  void Update()
//  {
//    bool canSpawn = GetCanSpawn();
//    if (canSpawn) { 
//      SpawnNextMinion(); 
//      lastSpawnTime = Time.time;
//    }
//  }

//  bool GetCanSpawn()
//  {
//    if (resources < GetMinionPrice(nextMinion)) { return false; }

//    if ((Time.time - lastSpawnTime) < SpawnInterval) { return false; }

//    return true;
//  }

//  void SpawnNextMinion()
//  {
//    PurchaseMinion(nextMinion);
//    IncrementNextMinion();
//  }

//  void IncrementNextMinion()
//  {
//    int nextMinionIndex = (((int)nextMinion) + 1) % minionTypeCount;
//    nextMinion = (MinionType)nextMinionIndex;
//    // Debug.Log(nextMinion);
//  }
//}
