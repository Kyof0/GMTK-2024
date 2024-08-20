//using Entities.People;
//using OldSystem.Entities;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public abstract class AntagonistAI : MonoBehaviour {

//  public enum Resource { Wood, Stone, Iron, Gold, Food};

//  // Can change this resources class to be a dictionary<Resource, float>
//  public class Resources
//  {
//    public float Wood { get; set; }
//    public float Stone { get; set; }
//    public float Iron { get; set; }
//    public float Gold { get; set; }
//    public float Food { get; set; }

//    public Resources()
//    {
//      Wood = 0;
//      Stone = 0;
//      Iron = 0;
//      Gold = 0;
//      Food = 0;
//    }

//    public Resources(float wood, float stone, float iron, float gold, float food)
//    {
//      Wood = wood;
//      Stone = stone;
//      Iron = iron;
//      Gold = gold;
//      Food = food;
//    }

//    public static bool operator >(Resources left, Resources right)
//    {
//      return left.Wood > right.Wood && left.Stone > right.Stone && left.Iron > right.Iron && left.Gold > right.Gold && left.Food > right.Food;
//    }

//    public static bool operator <(Resources left, Resources right)
//    {
//      return left.Wood < right.Wood && left.Stone < right.Stone && left.Iron < right.Iron && left.Gold < right.Gold && left.Food < right.Food;
//    }

//    public static Resources operator -(Resources left, Resources right)
//    {
//      return new Resources
//      { 
//      Wood = left.Wood - right.Wood,
//      Stone = left.Stone - right.Stone,
//      Iron = left.Iron - right.Iron,
//      Gold = left.Gold - right.Gold,
//      Food = left.Food - right.Food,
//      };
//    }

//    public static Resources operator +(Resources left, Resources right)
//    {
//      return new Resources
//      {
//        Wood = left.Wood + right.Wood,
//        Stone = left.Stone + right.Stone,
//        Iron = left.Iron + right.Iron,
//        Gold = left.Gold + right.Gold,
//        Food = left.Food + right.Food,
//      };
//    }

//  }

//  public Resources resources = new Resources();

//  public enum MinionType { Miner, Farmer, Soldier, LumberJack };
//  // The list should be in the same order as the enum
//  public List<GameObject> Minions;

//  //public MinionType GetMinionType(Resource resource) 
//  //{
//  //  switch (resource)
//  //  {
//  //    case Resource.Wood: return MinionType.LumberJack;
//  //    case Resource.Stone: return MinionType.Miner;
//  //    case Resource.Iron: return MinionType.Miner;
//  //    case Resource.Gold: return MinionType.Miner;
//  //    case Resource.Food: return MinionType.Farmer;
//  //    default:
//  //      Debug.LogError("Unknown resource");
//  //      return MinionType.Soldier;
//  //  }
   
//  //}


//  // Start is called before the first frame update
//  void Start() {

//  }

//  // Update is called once per frame
//  void Update() {

//  }

//  protected void PurchaseMinion(MinionType minion)
//  {
//    var cost = GetMinionPrice(minion);
//    if (cost > resources) {
//      Debug.LogError("Attempted to purchase an unaffordable minion. Use \"CanPurchaseMinion()\" to determine");
//      return;
//    }

//    resources -= cost;
//    SpawnMinion(minion);
//  }


//  // Wood, Stone, Iron, Gold, Food
//  protected Resources GetMinionPrice(MinionType minion)
//  {
//    // Implement minion costs
//    return new Resources();
//  }

//  private void SpawnMinion(MinionType minion)
//  {
//        InstantiateMinion(minion);
//  }

//  private void InstantiateMinion(MinionType minionType)
//  {
//    if(Minions.Count > (int)minionType)
//    {
//      var minion = Minions[(int)minionType];
//      Instantiate(minion, transform.position, Quaternion.identity);
//    } 
//    else
//    {
//      Debug.Log("Attempted to spawn an unassigned minion");
//    }
//    // var instance = Instantiate(minion, transform.position, Quaternion.identity);
//    // var minionScript = instance.GetComponent<Collector>();
//    // minionScript.Targets = this.targets;
//    // minionScript.GameManager = this;
//  }

//}
