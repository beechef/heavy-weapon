using Runtime.Bullets.Stats;
using UnityEngine;

namespace Runtime.Bullets.StatsSystems
{
    public class BasicStatsSystem : MonoBehaviour
    {
        [SerializeField] protected BasicStats stats;
        public BasicStats Stats => stats;

        protected virtual void OnEnable()
        {
            stats = Instantiate(stats);
            stats.health = stats.maxHealth;
        }

        public bool IsDead() => stats.health <= 0f;

        public virtual bool TakeDamage(float damage)
        {
            stats.health = Mathf.Clamp(stats.health - damage, 0f, stats.maxHealth);
            return IsDead();
        }
    }
}