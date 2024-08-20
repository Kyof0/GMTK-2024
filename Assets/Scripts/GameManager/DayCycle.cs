using Entities.People;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace GameManager
{
    public class DayCycle : MonoBehaviour
    {
        public DayCycleManager dayCycleManager;

        public GameManager gameManager;

        public TribePopulation tribePopulation;

        public float dayTime = 60;
        public bool isSecond = true;
        public bool dayStart = true;
        public bool dayEnd = false;
        private void Start()
        {
            gameManager = GetComponent<GameManager>();
            tribePopulation = GetComponent<TribePopulation>();
            gameManager.InstantiateAnimals();
        }
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
            gameManager.TriggerOnDawn();
            for (int i = 0; i < tribePopulation._minerCount; i++)
            {
                gameManager.InstantiateMiner();
            }
            Debug.Log("Day Started");
        }
        public void DayEnd()
        {
            gameManager.TriggerOnDusk();
            ResetTime(60f);
            //Pause states, workers etc. 
            dayCycleManager.ActivateEndDayButton();
            //Do actions.
            Debug.Log("Day Ended");
            dayStart = true;
        }
        public void EndDayButton()
        {
            foreach (var item in GameObject.FindGameObjectsWithTag("TribeMember"))
            {
                Destroy(item);

            };
            Debug.Log("sa");
            //Start day.
            dayCycleManager.DeactivateEndDayButton();
            dayEnd = false;
        }
    }
}