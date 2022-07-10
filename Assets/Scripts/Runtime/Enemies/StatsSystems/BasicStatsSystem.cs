using Runtime.Enemies.Stats;
using UnityEngine;

namespace Runtime.Enemies.StatsSystems
{
    public class BasicStatsSystem : MonoBehaviour
    {
        [SerializeField] private BasicStats stats;
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