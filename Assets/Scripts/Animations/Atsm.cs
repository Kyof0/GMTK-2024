using System;
using UnityEngine;

namespace Animations
{
    public class Atsm : MonoBehaviour
    {
        private Rigidbody2D Rb;

        private Animator Anim;

        private void Awake()
        {
            Rb = transform.GetComponent<Rigidbody2D>();

            Anim = transform.GetComponent<Animator>();
        }

        private void Update()
        {
            Anim.SetBool("move", Rb.velocity != Vector2.zero);
        }
    }
}