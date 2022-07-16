using System;
using UnityEngine;

namespace Runtime.Bullets.Behaviours
{
    public class Gravity : MonoBehaviour
    {
        private const float G = 3f;
        [SerializeField] protected Rigidbody2D rb;

        private bool _isGround = false;

        private void OnEnable()
        {
            _isGround = false;
        }

        private void FixedUpdate()
        {
            Vector3 velocity = rb.velocity;
            if (_isGround)
                velocity.y = 0f;
            else
                velocity.y -= G * Time.fixedDeltaTime;
            rb.velocity = velocity;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(TagName.Ground))
            {
                _isGround = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(TagName.Ground))
            {
                _isGround = false;
            }
        }
    }
}