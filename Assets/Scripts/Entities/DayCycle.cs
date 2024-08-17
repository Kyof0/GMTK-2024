using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DayCycle : MonoBehaviour
{
    public Image _cycleBar;

    public float dayTime = 60;
    public bool isSecond = true;
    public bool dayStart = true;
    public bool dayEnd = false;
    void Update()
    {
        if (!dayEnd)
        {
            if (dayTime > 0)
            {
                if (dayStart)
                {
                    DayStart();
                    dayStart = false;
                }
                if (isSecond)
                {
                    StartCoroutine(DayAndNight(1f));
                    isSecond = false;
                }
            }
            else
            {
                dayEnd = true;
            }
        }
        else
        {
            DayEnd();
        }
    }
    public IEnumerator DayAndNight(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpendTime(1f);
        isSecond = true;
    }
    public void SpendTime(float time)
    {
        dayTime -= time;
        _cycleBar.fillAmount = dayTime/60f;
    }
    public void ResetTime(float time)
    {
        dayTime = time;
        _cycleBar.fillAmount = dayTime/60f;
    }
    public void DayStart()
    {
        //Start states, workers etc. here
        Debug.Log("Day Started");
    }
    public void DayEnd()
    {
        ResetTime(60f);
        //Pause states, workers etc. 
        //Do actions.
        Debug.Log("Day Ended");
        dayStart = true;
        dayEnd = false;
    }
}
