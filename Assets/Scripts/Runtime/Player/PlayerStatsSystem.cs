using System;
using Runtime.Enemy;
using Runtime.Items;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Player
{
    public class PlayerStatsSystem : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        [SerializeField] private ProgressRenderer progressRenderer;
        [SerializeField] private HealthBarRenderer healthBarRenderer;
        public PlayerStats Stats => stats;
        private bool _isFirst = false;
        public Action OnInit;

        protected virtual void Awake()
        {
            GODictionary.AddPlayerStatsSystem(gameObject, this);
        }

        protected virtual void OnEnable()
        {
            Init();
        }

        private void Update()
        {
            UpdateMegaLaserProgress();
        }

        protected virtual void Init()
        {
            if (!_isFirst)
            {
                _isFirst = true;
                stats = Instantiate(stats);
                OnInit?.Invoke();
            }

            RestoreFullHealth();
        }

        public void RestoreFullHealth()
        {
            stats.health = stats.maxHealth;
            healthBarRenderer.Render(stats.health, stats.maxHealth);
        }

        public bool IsDead() => stats.health <= 0f;

        public virtual bool TakeDamage(float damage)
        {
            stats.health = Mathf.Clamp(stats.health - damage, 0f, stats.maxHealth);
            healthBarRenderer.Render(stats.health, stats.maxHealth);

            return IsDead();
        }

        public void UpdateMegaLaserProgress()
        {
            stats.megaLaserComplete = Mathf.Clamp(stats.megaLaserComplete, 0f, 100f);
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