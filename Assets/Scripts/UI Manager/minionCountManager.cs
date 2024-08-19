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
    public void UpdateText(string textCode, bool isNight)
    {
        switch (textCode){
            case "p":
                _peasantCountText.text = NewText(_peasantCountText.text, true).ToString();
                tribe.PeasantCount(-1);
                _peasantCountText.color = Color.white;
                if (isNight) _peasantCountText.color = Color.gray;
                break;
            case "r":
                _reverendCountText.text= NewText(_reverendCountText.text, false).ToString();
                tribe.ReverendCount(1);
                _reverendCountText.color = Color.white;
                if (isNight) _reverendCountText.color = Color.gray;
                break;
            case "w":
                _warriorCountText.text= NewText(_warriorCountText.text, false).ToString();
                tribe.WarriorCount(1);
                _warriorCountText.color = Color.white;
                if (isNight) _warriorCountText.color = Color.gray;
                break;
            case "m":
                _minerCountText.text= NewText(_minerCountText.text, false).ToString();
                tribe.MinerCount(1);
                _minerCountText.color = Color.white;
                if (isNight) _minerCountText.color = Color.gray;
                break;
            case "l":
                _lumberjackCountText.text = NewText(_lumberjackCountText.text, false).ToString();
                tribe.LumberjackCount(1);
                _lumberjackCountText.color = Color.white;
                if (isNight) _lumberjackCountText.color = Color.gray;
                break;
            case "s":
                _shepherdCountText.text = NewText(_shepherdCountText.text, false).ToString();
                tribe.ShepherdCount(1);
                _shepherdCountText.color = Color.white;
                if (isNight) _shepherdCountText.color = Color.gray;
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
        if (isNight) {
            if (Convert.ToInt32(_peasantCountText.text) > 0)
            {
                UpdateText(textCode, isNight);
                UpdateText("p", isNight);
            }
        }
    }
    #endregion
}
