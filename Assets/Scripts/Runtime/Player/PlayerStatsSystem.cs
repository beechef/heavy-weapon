using UnityEngine;

namespace Runtime.Player
{
    public class PlayerStatsSystem : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;

        public PlayerStats Stats => stats;

        protected virtual void Awake()
        {
            GODictionary.AddPlayerStatsSystem(gameObject, this);
        }

        protected virtual void OnEnable()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {
            stats = Instantiate(stats);
            RestoreFullHealth();
        }

        public void RestoreFullHealth()
        {
            stats.health = stats.maxHealth;
        }

        public bool IsDead() => stats.health <= 0f;

        public virtual bool TakeDamage(float damage)
        {
            stats.health = Mathf.Clamp(stats.health - damage, 0f, stats.maxHealth);
            return IsDead();
        }

        public virtual void IncreaseAttack(float attack)
        {
            stats.attack += attack;
        }

        public virtual void DecreaseAttack(float attack)
        {
            stats.attack -= attack;
        }
    }
}