using System;
using System.Collections.Generic;
using System.Linq;
using Entities.People;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

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

        public GameObject[] minions;

        private float _lastSpawnTime;

        public Transform[] targets;

        public HashSet<Transform> Animals;

        public HashSet<Transform> EnemyTribeMembers;
        
        #endregion
        
        #region Action Events

        public event Action OnDawn;
        public event Action OnDusk;

        public event Action OnPeace;
        public event Action OnWar;

        public void TriggerOnDawn()
        {
            OnDawn?.Invoke();
        }
        public void TriggerOnDusk()
        {
            OnDusk?.Invoke();
        }
        public void TriggerOnWar()
        {
            OnWar?.Invoke();
        }
        public void TriggerOnPeace()
        {
            OnPeace?.Invoke();
        }
        #endregion

        #region Unity Callback Functions

        private void Start()
        {
            _lastSpawnTime = Time.time;
            
            // InstantiateMinion(miner);
            
            // The following part should be executed after the animals are spawned

            // var animals = GameObject.FindGameObjectsWithTag("Animal");
            //
            // foreach (var animal in animals)
            // {
            //     Animals.Add(animal.transform);
            // }
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

            //if (_lit && !_litPrev) OnDawn?.Invoke();

            //if (_litPrev && !_lit) OnDusk?.Invoke();

            _litPrev = _lit;

            if (Time.time > _lastSpawnTime + 1f)
            {
                // The following part should be executed after the animals are spawned
                
                // var enemyTribeMembers = GameObject.FindGameObjectsWithTag("TribeMember");
                //
                // foreach (var tribeMember in enemyTribeMembers)
                // {
                //     EnemyTribeMembers.Add(tribeMember.transform);
                // }
                
                _lastSpawnTime = Time.time;
            }
        }

        #endregion

        #region Functions

        public void InstantiateMiner()
        {
            var instance = Instantiate(minions[8], transform.position, Quaternion.identity);
            var minionScript = instance.GetComponent<Collector>();
            Transform[] arr = { targets[Random.Range(0,29)], targets[29] };
            minionScript.Targets = arr;
            minionScript.GameManager = this;
        }
        public void InstantiateLumberjack()
        {
            var instance = Instantiate(minions[7], transform.position, Quaternion.identity);
            var minionScript = instance.GetComponent<Collector>();
            Transform[] arr = { targets[Random.Range(31, 81)], targets[29] };
            minionScript.Targets = arr;
            minionScript.GameManager = this;
        }
        
        /// <summary>
        /// This method should be called after InstantiateAnimals
        /// </summary>
        public void InstantiateShepherd()
        {
            var instance = Instantiate(minions[9], transform.position, Quaternion.identity);
            var minionScript = instance.GetComponent<Collector>();
            if (Animals.Count < 12) return;
            Transform[] arr = { Animals.ToArray()[Random.Range(0, 12)], targets[29] };
            minionScript.Targets = arr;
            minionScript.GameManager = this;
        }

        /// <summary>
        /// This method should be called before InstantiateShepherd
        /// </summary>
        public void InstantiateAnimals()
        {
            var pos = Vector3.zero;
            var tp = targets[81].position;

            for (int i = 0; i < 3; i++)
            {
                pos.Set(tp.x + Random.Range(-2, 3), tp.y + Random.Range(-2, 3), 0);
                Animals.Add(Instantiate(minions[1], pos,Quaternion.Euler(0f, 0f, 0f)).transform);
            }
            for (int i = 0; i < 3; i++)
            {
                pos.Set(tp.x + Random.Range(-2, 3), tp.y + Random.Range(-2, 3), 0);
                Animals.Add(Instantiate(minions[2], pos,Quaternion.Euler(0f, 0f, 0f)).transform);
            }
            for (int i = 0; i < 3; i++)
            {
                pos.Set(tp.x + Random.Range(-2, 3), tp.y + Random.Range(-2, 3), 0);
                Animals.Add(Instantiate(minions[3], pos,Quaternion.Euler(0f, 0f, 0f)).transform);
            }
            for (int i = 0; i < 3; i++)
            {
                pos.Set(tp.x + Random.Range(-2, 3), tp.y + Random.Range(-2, 3), 0);
                Animals.Add(Instantiate(minions[4], pos,Quaternion.Euler(0f, 0f, 0f)).transform);
            }
            tp = targets[82].position;
            for (int i = 0; i < 3; i++)
            {
                pos.Set(tp.x + Random.Range(-2, 3), tp.y + Random.Range(-2, 3), 0);
                Animals.Add(Instantiate(minions[1], pos, Quaternion.Euler(0f, 0f, 0f)).transform);
            }
            for (int i = 0; i < 3; i++)
            {
                pos.Set(tp.x + Random.Range(-2, 3), tp.y + Random.Range(-2, 3), 0);
                Animals.Add(Instantiate(minions[2], pos, Quaternion.Euler(0f, 0f, 0f)).transform);
            }
            for (int i = 0; i < 3; i++)
            {
                pos.Set(tp.x + Random.Range(-2, 3), tp.y + Random.Range(-2, 3), 0);
                Animals.Add(Instantiate(minions[3], pos, Quaternion.Euler(0f, 0f, 0f)).transform);
            }
            for (int i = 0; i < 3; i++)
            {
                pos.Set(tp.x + Random.Range(-2, 3), tp.y + Random.Range(-2, 3), 0);
                Animals.Add(Instantiate(minions[4], pos, Quaternion.Euler(0f, 0f, 0f)).transform);
            }
        }

        #endregion
    }
}