using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AntagonistAI : MonoBehaviour {

  public class Resources
  {
    public float Wood { get; set; }
    public float Stone { get; set; }
    public float Iron { get; set; }
    public float Gold { get; set; }
    public float Food { get; set; }

    public Resources()
    {
      Wood = 0;
      Stone = 0;
      Iron = 0;
      Gold = 0;
      Food = 0;
    }

    public Resources(float wood, float stone, float iron, float gold, float food)
    {
      Wood = wood;
      Stone = stone;
      Iron = iron;
      Gold = gold;
      Food = food;
    }

    public static bool operator >(Resources left, Resources right)
    {
      return left.Wood > right.Wood && left.Stone > right.Stone && left.Iron > right.Iron && left.Gold > right.Gold && left.Food > right.Food;
    }

    public static bool operator <(Resources left, Resources right)
    {
      return left.Wood < right.Wood && left.Stone < right.Stone && left.Iron < right.Iron && left.Gold < right.Gold && left.Food < right.Food;
    }

    public static Resources operator -(Resources left, Resources right)
    {
      return new Resources
      { 
      Wood = left.Wood - right.Wood,
      Stone = left.Stone - right.Stone,
      Iron = left.Iron - right.Iron,
      Gold = left.Gold - right.Gold,
      Food = left.Food - right.Food,
      };
    }

    public static Resources operator +(Resources left, Resources right)
    {
      return new Resources
      {
        Wood = left.Wood + right.Wood,
        Stone = left.Stone + right.Stone,
        Iron = left.Iron + right.Iron,
        Gold = left.Gold + right.Gold,
        Food = left.Food + right.Food,
      };
    }

  }

  protected Resources resources = new Resources();

  protected enum MinionType { Miner, Farmer, Soldier };

  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  protected void PurchaseMinion(MinionType minion)
  {
    var cost = GetMinionPrice(minion);
    if (cost > resources) {
      Debug.LogError("Attempted to purchase an unaffordable minion. Use \"CanPurchaseMinion()\" to determine");
      return;
    }

    resources -= cost;
    SpawnMinion(minion);
  }


  // Wood, Stone, Iron, Gold, Food
  protected Resources GetMinionPrice(MinionType minion)
  {
    // Implement minion costs
    return new Resources();
  }

  private void SpawnMinion(MinionType minion)
  {

    switch (minion)
    {
      case MinionType.Miner:
        // spawn enemy miner
        Debug.Log("[AntagonistAI] TODO: Spawn enemy miner");
        break;
      case MinionType.Farmer:
        // spawn enemy farmer
        Debug.Log("[AntagonistAI] TODO: Spawn enemy farmer");
        break;
      case MinionType.Soldier:
        // spawn enemy soldier
        Debug.Log("[AntagonistAI] TODO: Spawn enemy soldier");
        break;
      default:
        Debug.LogError("Attempted to spawn an unknown minion");
        break;
    }
  }

}
