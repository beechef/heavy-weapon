using Runtime.Bullets.StatsSystems;
using UnityEngine;
using BasicStats = Runtime.Bullets.Stats.BasicStats;

namespace Runtime.Bullets.Behaviours
{
    public class MoveUpBehaviour : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] private BasicStatsSystem statsSystem;
        private BasicStats _stats;

        protected virtual void OnEnable()
        {
            OnInit();
        }

        private void OnInit()
        {
            _stats = statsSystem.Stats;
        }

        protected virtual void FixedUpdate()
        {
            Vector2 velocity = transform.up * _stats.moveSpeed;
            rb.velocity = velocity;
        }
    }
}