using Runtime.Bullets.StatsSystems;
using UnityEngine;
using BasicStats = Runtime.Bullets.Stats.BasicStats;

namespace Runtime.Bullets.Behaviours
{
    public class DropBehaviour : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] private BasicStatsSystem statsSystem;
        private BasicStats _stats;

        protected virtual void OnEnable()
        {
            _stats = statsSystem.Stats;
        }

        protected virtual void FixedUpdate()
        {
            Vector2 velocity = rb.velocity;
            velocity.y -= _stats.moveSpeed * Time.deltaTime;
            rb.velocity = velocity;
        }
    }
}