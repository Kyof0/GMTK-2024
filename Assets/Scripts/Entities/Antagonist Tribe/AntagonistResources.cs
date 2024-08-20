using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntagonistResources : MonoBehaviour
{
    public int _woodCount = 0;
    public int _stoneCount = 0;
    public int _ironCount = 0;
    public int _foodCount = 0;
    public float _stamina = 0;


    public TribePopulation tribe;
    public float ResourceRegenInterval = 2f;
    private float lastRegen;

  public ResourcesManager resourcesManager;
    public void Wood(int amount)
    {
        _woodCount += amount;
        resourcesManager.UpdateText("w", _woodCount);
    }
    public void Stone(int amount)
    {
        _stoneCount += amount;
        resourcesManager.UpdateText("s", _stoneCount);
    }
    public void Iron(int amount)
    {
        _ironCount += amount;
        resourcesManager.UpdateText("i", _ironCount);
    }
    public void Food(int amount)
    {
        _foodCount += amount;
        resourcesManager.UpdateText("f", _foodCount);
    }
    public void Stamina(float amount)
    {
        _stamina += amount;
        _stamina = Mathf.Clamp(_stamina, 0, 100);
        resourcesManager.UpdateStamina(_stamina);
    }
    private void Update()
    {

        if (Time.time - lastRegen > ResourceRegenInterval)
        {
            Stamina(tribe._reverendCount);
            lastRegen = Time.time;
        }
  }

}