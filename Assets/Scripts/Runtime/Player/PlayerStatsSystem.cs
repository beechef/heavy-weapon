using Runtime.Items;
using UnityEngine;

namespace Runtime.Player
{
    public class PlayerStatsSystem : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        [SerializeField] private TankExplosion _explosion;
        [SerializeField] private ProgressRenderer progressRenderer;
        public PlayerStats Stats => stats;
        private bool _isFirst = false;

        protected virtual void Awake()
        {
            GODictionary.AddPlayerStatsSystem(gameObject, this);
        }

        protected virtual void OnEnable()
        {
            OnInit();
        }

        private void Update()
        {
            UpdateMegaLaserProgress();
            if (IsDead())
            {
                _explosion.ExplosionByPress();
            }
        }

        protected virtual void OnInit()
        {
            if (!_isFirst)
            {
                _isFirst = true;
                stats = Instantiate(stats);
            }

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

        public void UpdateMegaLaserProgress()
        {
            if (stats.megaLaserComplete >= 99f)
            {
                stats.isActivateMegaLaser = true;
            }

            if (stats.isActivateMegaLaser)
            {
                if (stats.megaLaserComplete <= 0f)
                {
                    stats.isActivateMegaLaser = false;
                }
                else
                {
                    stats.megaLaserComplete -= Time.deltaTime * 10f;
                }
            }

            progressRenderer.Render(stats.megaLaserComplete, 100f);
        }
    }
}