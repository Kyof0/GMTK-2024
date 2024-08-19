using UnityEngine;

namespace OldSystem.CoreSystem.CoreComponents
{
    public class Movement : CoreComponent
    {
        // This core component supplies the entity with all kinds of movement functions.

        #region Parameters

        private Rigidbody2D Rb;

        private Vector2 _workspace; // So that we don't create a new Vector2 every time we set the velocity

        public int facingDirection;

        #endregion

        #region Unity Callback Functions

        protected override void Awake()
        {
            base.Awake();

            Rb = GetComponentInParent<Rigidbody2D>();
        }

        #endregion

        #region Functions

        public void Move(float velocity, Vector2 direction)
        {
            _workspace = velocity * direction;
            Rb.velocity = _workspace;
        }

        public void Stop()
        {
            _workspace = Vector2.zero;
            Rb.velocity = _workspace;
        }

        public void Flip()
        {
            facingDirection = -facingDirection;
            Rb.transform.Rotate(0.0f, 180.0f, 0.0f);
        }

        #endregion
    }
}