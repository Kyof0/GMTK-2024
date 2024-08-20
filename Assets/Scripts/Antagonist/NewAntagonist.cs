using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAntagonist : MonoBehaviour
{
  public TribePopulation Population;
  public TribeResources Resources;

  public float UpdateInterval = 1.0f;
  private float lastUpdate;

  private int nextPop = 0;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Time.time - lastUpdate >= UpdateInterval)
    {
      IncrementPopulation();
      IncreaseResources();
    }
  }

  void IncrementPopulation()
  {
    switch (nextPop)
    {
      case 0:
        Population.LumberjackCount(1);
        break;

      case 1:
        Population.MinerCount(1);
        break;

      case 2:
        Population.PeasantCount(1);
        break;

      case 3:
        Population.ShepherdCount(1);
        break;

      case 4:
        Population.WarriorCount(1);
        break;
    }

    nextPop = (nextPop + 1) % 5;
  }

  void IncreaseResources()
  {
    Resources.Wood(Population._lumberjackCount);
    Resources.Stone(Population._peasantCount);
    Resources.Iron(Population._minerCount);
    Resources.Food(Population._shepherdCount);
  }
}

