using UnityEngine;

namespace Runtime.Bullets
{
    public class PlayerShield : BasicBullet
    {
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            OnCollision(other.collider);
        }

        public override void TakeDamage(float damage)
        {
        }
    }
}