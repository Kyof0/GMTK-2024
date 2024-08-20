using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribePopulation : MonoBehaviour
{
    public int _peasantCount = 0;
    public int _reverendCount = 0;
    public int _warriorCount = 0;
    public int _minerCount = 0;
    public int _lumberjackCount = 0;
    public int _shepherdCount = 0;
    public int _populationCount = 0;
    
    public MinionCountManager minionManager;
    public void PeasantCount(int amount)
    {
        _peasantCount += amount;
        _populationCount += amount;
        minionManager.SetText("p", _peasantCount);
    }
    public void LumberjackCount(int amount)
    {
        _lumberjackCount += amount;
        _populationCount += amount;
        minionManager.SetText("l", _lumberjackCount);
    }
    public void MinerCount(int amount)
    {
        _minerCount += amount;
        _populationCount += amount;
        minionManager.SetText("m", _minerCount);
    }
    public void WarriorCount(int amount)
    {
        _warriorCount += amount;
        _populationCount += amount;
        minionManager.SetText("w", _warriorCount);
    }
    public void ShepherdCount(int amount)
    {
        _shepherdCount += amount;
        _populationCount += amount;
        minionManager.SetText("s", _shepherdCount);
    }
    public void ReverendCount(int amount)
    {
        _reverendCount += amount;
        _populationCount += amount;
        minionManager.SetText("r", _reverendCount);
    }

}