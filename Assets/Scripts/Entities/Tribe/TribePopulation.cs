using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribePopulation : MonoBehaviour
{
    public int _peasantCount;
    public int _reverendCount;
    public int _warriorCount;
    public int _minerCount;
    public int _lumberjackCount;
    public int _shepherdCount;
    public int _populationCount;

    public void PeasantCount(int amount)
    {
        _peasantCount += amount;
    }
    public void LumberjackCount(int amount)
    {
        _lumberjackCount += amount;
    }
    public void MinerCount(int amount)
    {
        _minerCount += amount;
    }
    public void WarriorCount(int amount)
    {
        _warriorCount += amount;
    }
    public void ShepherdCount(int amount)
    {
        _shepherdCount += amount;
    }
    public void ReverendCount(int amount)
    {
        _reverendCount += amount;
    }
}