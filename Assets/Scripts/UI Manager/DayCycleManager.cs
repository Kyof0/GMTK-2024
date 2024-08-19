using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DayCycleManager : MonoBehaviour
{
    #region Cycle Bar
    public Image _cycleBar;
    
    public void SpendTime(float time)
    {
        _cycleBar.fillAmount = time / 60f;
    }
    public void ResetTime(float time)
    {
        _cycleBar.fillAmount = time / 60f;
    }
    #endregion
    #region Start Day Button
    public GameObject endDayButton;
    public void DeactivateEndDayButton()
    {
        endDayButton.SetActive(false);
    }
    public void ActivateEndDayButton()
    {
        endDayButton.SetActive(true);
    }
    #endregion
}
