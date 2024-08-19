using System;
using Entities.People;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        #region Lighting Parameters

        public GameObject[] spotLights;

        public Light2D globalLight;

        public AnimationCurve dayCycle;

        private bool _lit;
        private bool _litPrev;

        #endregion

        #region Spawn Parameters

        public GameObject miner;

        private float _lastSpawnTime;

        public Transform[] targets;
        
        #endregion
        
        #region Action Events

        public event Action OnDawn;
        public event Action OnDusk;

        #endregion

        #region Unity Callback Functions

        private void Start()
        {
            _lastSpawnTime = Time.time;
            
            // InstantiateMinion(miner);
        }

        private void Update()
        {
            globalLight.intensity = dayCycle.Evaluate((Time.time / 20)) + 0.2f;

            if (dayCycle.Evaluate((Time.time / 20)) + 0.2f > 0.5f)
            {
                foreach (var spotLight in spotLights) spotLight.GetComponent<Light2D>().intensity = 0f;
                
                _lit = true;
            }
            else
            {
                foreach (var spotLight in spotLights) spotLight.GetComponent<Light2D>().intensity = 1f;

                _lit = false;
            }

            if (_lit && !_litPrev) OnDawn?.Invoke();

            if (_litPrev && !_lit) OnDusk?.Invoke();

            _litPrev = _lit;

            if (Time.time > _lastSpawnTime + 1f)
            {
                InstantiateMinion(miner);
                _lastSpawnTime = Time.time;
            }
        }

        #endregion

        #region Functions

        private void InstantiateMinion(GameObject minion)
        {
            var instance = Instantiate(minion, transform.position, Quaternion.identity);
            var minionScript = instance.GetComponent<Miner>();
            minionScript.Targets = this.targets;
            minionScript.GameManager = this;
        }

        #endregion
    }
}