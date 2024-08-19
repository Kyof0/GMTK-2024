using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tribe : MonoBehaviour
{
    public int _peasantCount;
    public int _lumberjackCount;
    public int _minerCount;
    public int _warriorCount;
    public int _shepherdCount;
    public int _reverendCount;
    public int _populationCount;

    public void PeasantCount(int amount)
    {
        _peasantCount += amount;
    }
    public void lumberjackCount(int amount)
    {
        _lumberjackCount += amount;
    }
    public void minerCount(int amount)
    {
        _minerCount += amount;
    }
    public void warriorCount(int amount)
    {
        _warriorCount += amount;
    }
    public void shepherdCount(int amount)
    {
        _shepherdCount += amount;
    }
    public void reverendCount(int amount)
    {
        _reverendCount += amount;
    }
}