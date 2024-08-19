using System;
using OldSystem.DataScriptableObjects.EntityDataScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Entities.People
{
    public class Wanderer : MonoBehaviour
    {
        public WandererData data;
        
        private Rigidbody2D _rb;

        private Vector2 _direction = Vector2.zero;

        private bool _move;

        private void Awake()
        {
            _rb = transform.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_move)
            {
                _rb.velocity = _direction.normalized * data.moveSpeed;
            }

            if (!_move)
            {
                _rb.velocity = Vector2.zero;
                
                _direction.Set(Random.Range(-1,2), Random.Range(-1,2));
            }

            _move = (Time.time % data.period > data.period / 2);
        }
    }
}