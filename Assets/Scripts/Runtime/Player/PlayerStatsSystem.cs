﻿using System;
using UnityEngine;

namespace Runtime.Player
{
    public class PlayerStatsSystem : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
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