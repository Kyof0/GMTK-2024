using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ResourcesManager : MonoBehaviour
{
    public TextMeshProUGUI _woodCountText;
    public TextMeshProUGUI _foodCountText;
    public TextMeshProUGUI _stoneCountText;
    public TextMeshProUGUI _ironCountText;

    public Image staminaBar;
    public void UpdateText(string code, int amount)
    {
        switch (code)
        {
            case "w":
                _woodCountText.text = amount.ToString();
                break;
            case "f":
                _foodCountText.text = amount.ToString();
                break;
            case "s":
                _stoneCountText.text = amount.ToString();
                break;
            case "i":
                _ironCountText.text = amount.ToString();
                break;
        }
    }
    public void UpdateStamina(float stamina)
    {
        staminaBar.fillAmount = stamina / 100f;

    }
}
