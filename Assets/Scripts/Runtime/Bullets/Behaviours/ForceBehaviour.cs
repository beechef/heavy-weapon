using Runtime.Bullets.Stats;
using Runtime.Bullets.StatsSystems;
using UnityEngine;

namespace Runtime.Bullets.Behaviours
{
    public class ForceBehaviour : MonoBehaviour
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
            rb.velocity = transform.up * _stats.moveSpeed;
        }
    }
}