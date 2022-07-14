using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Runtime.Interfaces;
using UnityEngine;

namespace Runtime.Player
{
    public class PlayerCombatSystem : MonoBehaviour, IVulnerable
    {
        [SerializeField] private PlayerStatsSystem statsSystem;
        [SerializeField] private PlayerAnimation anim;
        [SerializeField] private Pooling pooling;
        [SerializeField] private List<Transform> attackPoints;
        [SerializeField] private string bulletPrefab;
        [SerializeField] private string casingPrefab;

        private PlayerStats _stats;
        private float _lastAttack;

        private void OnEnable()
        {
            OnInit();
        }

        private void OnInit()
        {
            _stats = statsSystem.Stats;
            GODictionary.AddVulnerableGO(gameObject, this);
        }

        private void Death()
        {
            _stats.lives--;
            // anim.Death();
            if (_stats.lives <= 0)
            {
                Debug.Log("Lose!");
            }
            else
            {
                Reborn();
            }
        }

        private void Reborn()
        {
            statsSystem.RestoreFullHealth();
        }

        public void TakeDamage(float damage)
        {
            // anim.Hit();
            if (statsSystem.TakeDamage(damage))
            {
                Death();
            }
        }

        public bool IsCanAttack()
        {
            return Time.time - _lastAttack >= 1f / _stats.attackSpeed;
        }


        public async void Attack()
        {
            if (!IsCanAttack()) return;
            _lastAttack = Time.time;
            for (int i = 0; i < _stats.amountAttackPoint; i++)
            {
                if (i >= attackPoints.Count) break;
                var attackPoint = attackPoints[i];
                var position = attackPoint.position;
                var rotation = attackPoint.rotation;
                GameObject go = await pooling.GetAsync(bulletPrefab, position,
                    rotation);
                GODictionary.BasicBulletStatsSystemGOs[go].IncreaseAttack(_stats.attack);
                pooling.GetAsync(casingPrefab, position, rotation).Forget();
            }
        }
    }
}