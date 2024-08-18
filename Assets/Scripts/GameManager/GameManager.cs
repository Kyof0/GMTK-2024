using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        public GameObject GlobalLightGameObject => GameObject.FindWithTag("GlobalLight");

        public GameObject[] SpotLights => GameObject.FindGameObjectsWithTag("SpotLight");
        public Light2D GlobalLight => GlobalLightGameObject.GetComponent<Light2D>();

        public AnimationCurve DayCycle;

        private bool done;

        public GameObject miner;
        
        private float _lastSpawnTime;

        private int count = 1;

        private void Start()
        {
            _lastSpawnTime = Time.time;
        }

        private void Update()
        {
            GlobalLight.intensity = DayCycle.Evaluate((Time.time / 60) % 1f) + 0.2f;

            if (DayCycle.Evaluate((Time.time / 60) % 1f) + 0.2f > 0.5f)
            {
                foreach (var spotLight in SpotLights)
                {
                    spotLight.GetComponent<Light2D>().intensity = 0f;
                    OnDawn?.Invoke();
                }
            }
            else
            {
                foreach (var spotLight in SpotLights)
                {
                    spotLight.GetComponent<Light2D>().intensity = 1f;
                    OnDusk?.Invoke();
                }
            }

            if (Time.time > _lastSpawnTime + 1f)
            {
                Instantiate(miner, transform.position, Quaternion.identity);
                _lastSpawnTime = Time.time;
            }
        }

        public event Action OnDusk;
        public event Action OnDawn;
    }
}