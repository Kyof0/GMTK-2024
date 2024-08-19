using System.Collections;
using UnityEngine;

namespace GameManager
{
    public class DayCycle : MonoBehaviour
    {
        public DayCycleManager dayCycleManager;


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
                    DayEnd();
                }
            }
            else
            {
                Debug.Log("night time");
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
            dayCycleManager.SpendTime(dayTime);
        }
        public void ResetTime(float time)
        {
            dayTime = time;
            dayCycleManager.ResetTime(dayTime);
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
            dayCycleManager.ActivateEndDayButton();
            //Do actions.
            Debug.Log("Day Ended");
            dayStart = true;
        }
        public void EndDayButton()
        {
            //Start day.
            dayCycleManager.DeactivateEndDayButton();
            dayEnd = false;
        }
    }
}