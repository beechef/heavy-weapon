using Runtime.Bullets.Stats;
using Runtime.Bullets.StatsSystems;
using UnityEngine;

namespace Runtime.Bullets.Behaviours
{
    public class ForceBehaviour : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] private ForceStatsSystem statsSystem;

        private ForceStats _stats;

        protected virtual void OnEnable()
        {
            _stats = statsSystem.ForceStats;
        }

        protected virtual void Start()
        {
            rb.velocity = transform.up * _stats.force;
        }
    }
}