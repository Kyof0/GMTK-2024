using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class minionCountManager : MonoBehaviour
{
    public TextMeshProUGUI _peasantCountText;
    public TextMeshProUGUI _reverendCountText;
    public TextMeshProUGUI _warriorCountText;
    public TextMeshProUGUI _minerCountText;
    public TextMeshProUGUI _lumberjackCountText;
    public TextMeshProUGUI _shepherdCountText;
    //public TextMeshProUGUI _populationCountText;

    public void UpdateText(char textCode, string newText, bool isNight)
    {
        switch (textCode){
            case 'p':
                _peasantCountText.text = newText;
                _peasantCountText.color = Color.white;
                if (isNight) _peasantCountText.color = Color.blue;
                break;
            case 'r':
                _reverendCountText.text= newText;
                _reverendCountText.color = Color.white;
                if (isNight) _reverendCountText.color = Color.blue;
                break;
            case 'w':
                _warriorCountText.text= newText;
                _warriorCountText.color = Color.white;
                if (isNight) _warriorCountText.color = Color.blue;
                break;
            case 'm':
                _minerCountText.text= newText;
                _minerCountText.color = Color.white;
                if (isNight) _minerCountText.color = Color.blue;
                break;
            case 'l':
                _lumberjackCountText.text = newText;
                _lumberjackCountText.color = Color.white;
                if (isNight) _lumberjackCountText.color = Color.blue;
                break;
            case 's':
                _shepherdCountText.text = newText;
                _shepherdCountText.color = Color.white;
                if (isNight) _shepherdCountText.color = Color.blue;
                break;
        }

    }
}
