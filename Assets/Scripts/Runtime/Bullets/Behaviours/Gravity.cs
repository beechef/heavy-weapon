using UnityEngine;

namespace Runtime.Bullets.Behaviours
{
    public class Gravity : MonoBehaviour
    {
        private const float G = 2f;
        [SerializeField] protected Rigidbody2D rb;

        private void FixedUpdate()
        {
            Vector3 velocity = rb.velocity;
            velocity.y -= G * Time.fixedDeltaTime;
            rb.velocity = velocity;
        }
    }
}