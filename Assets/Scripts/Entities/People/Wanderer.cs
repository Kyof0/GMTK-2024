using System;
using OldSystem.DataScriptableObjects.EntityDataScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Entities.People
{
    public class Wanderer : MonoBehaviour
    {
        #region Data and Components

        public WandererData data;

        private Animator _anim;

        private Rigidbody2D _rb;

        #endregion

        #region Parameters

        private Vector2 _direction = Vector2.zero;

        private bool _move;

        #endregion

        #region Unity Callback Functions

        private void Awake()
        {
            _anim = GetComponent<Animator>();
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
            
            _anim.SetBool("move", _move);
        }

        #endregion
    }
}