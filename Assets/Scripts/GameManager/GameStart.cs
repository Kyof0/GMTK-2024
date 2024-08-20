using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private TribePopulation tribePopulation;
    private TribeResources tribeResources;
    [Header("Population Count")]
    public int _PeasantCount;
    public int _ReverendCount;
    public int _WarriorCount;
    public int _MinerCount;
    public int _LumberjackCount;
    public int _ShepherdCount;
    [Space(2)]
    [Header("Resources Count")]
    public int _woodCount;
    public int _foodCount;
    public int _stoneCount;
    public int _ironCount;
    public void Start()
    {
        tribePopulation = GetComponent<TribePopulation>();
        tribeResources = GetComponent<TribeResources>();

        tribePopulation.PeasantCount(_PeasantCount);
        tribePopulation.ReverendCount(_ReverendCount);
        tribePopulation.WarriorCount(_WarriorCount);
        tribePopulation.MinerCount(_MinerCount);
        tribePopulation.LumberjackCount(_LumberjackCount);
        tribePopulation.ShepherdCount(_ShepherdCount);

        tribeResources.Wood(_woodCount);
        tribeResources.Stone(_foodCount);
        tribeResources.Iron(_stoneCount);
        tribeResources.Food(_ironCount);
        tribeResources.Stamina(0);
    }
}
