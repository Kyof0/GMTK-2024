using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using GameManager;

public class MinionCountManager : MonoBehaviour
{
  #region Left Bar
  public TextMeshProUGUI _peasantCountText;
  public TextMeshProUGUI _reverendCountText;
  public TextMeshProUGUI _warriorCountText;
  public TextMeshProUGUI _minerCountText;
  public TextMeshProUGUI _lumberjackCountText;
  public TextMeshProUGUI _shepherdCountText;
  //public TextMeshProUGUI _populationCountText;

  public DayCycle dayCycle;
  public TribePopulation tribe;


  //Only can accesed during day by AI
  public void SetText(string textCode, int count)
  {
    switch (textCode)
    {
      case "p":
        _peasantCountText.text = count.ToString();
        break;
      case "r":
        _reverendCountText.text = count.ToString();
        break;
      case "w":
        _warriorCountText.text = count.ToString();
        break;
      case "m":
        _minerCountText.text = count.ToString();
        break;
      case "l":
        _lumberjackCountText.text = count.ToString();
        break;
      case "s":
        _shepherdCountText.text = count.ToString();
        break;
    }
  }
  //Only can accessed during night by player
  public void UpdateText(string textCode)
  {
    switch (textCode)
    {
      case "p":
        //_peasantCountText.text = NewText(_peasantCountText.text, true).ToString();
        tribe.PeasantCount(-1);
        break;
      case "r":
        //_reverendCountText.text= NewText(_reverendCountText.text, false).ToString();
        tribe.ReverendCount(1);
        break;
      case "w":
        //_warriorCountText.text= NewText(_warriorCountText.text, false).ToString();
        tribe.WarriorCount(1);
        break;
      case "m":
        //_minerCountText.text= NewText(_minerCountText.text, false).ToString();
        tribe.MinerCount(1);
        break;
      case "l":
        //_lumberjackCountText.text = NewText(_lumberjackCountText.text, false).ToString();
        tribe.LumberjackCount(1);
        break;
      case "s":
        //_shepherdCountText.text = NewText(_shepherdCountText.text, false).ToString();
        tribe.ShepherdCount(1);
        break;
    }

  }
  public int NewText(string text, bool isPeasent)
  {
    if (isPeasent)
    {
      int newText = Convert.ToInt32(text);
      return --newText;
    }
    else
    {
      int newText = Convert.ToInt32(text);
      return ++newText;
    }
  }
  public void AddButtonClicked(string textCode)
  {
    bool isNight = dayCycle.dayEnd;
    if (isNight)
    {
      if (Convert.ToInt32(_peasantCountText.text) > 0)
      {
        UpdateText(textCode);
        UpdateText("p");
      }
    }
  }
  #endregion

  #region James-Calvin's quick and dirty prayer stamina 
  // I put this in this script because it seemed the closest fit
  // I only had time tonight for this simple implementation
  // Here, I just increase stamina based on the number of 
  // reverends who exist. 

  // We should make a tribe management script somewhere which
  // manages the resources. This code would be better placed in
  // that script
  TribeResources resources = new TribeResources();
  public float ResourceRegenInterval = 2f;
  private float lastRegen;

  public void Update()
  {
    if (Time.time - lastRegen > ResourceRegenInterval)
    {
      resources.Stamina(tribe._reverendCount);
      lastRegen = Time.time;
      // If needed, other resources can go here.
      Debug.Log(resources._stamina);
    }
  }
  #endregion
}
