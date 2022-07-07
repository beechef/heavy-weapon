﻿using System.Collections;
using Runtime.Enemies.Animations;
using Runtime.Interfaces;
using UnityEngine;

namespace Runtime.Enemies.CombatSystems
{
    [RequireComponent(typeof(Collider2D))]
    public class BasicCombatSystem : MonoBehaviour, IVulnerable
    {
        [SerializeField] protected BasicAnimation anim;
        [SerializeField] protected Enemies.StatsSystems.BasicStatsSystem statsSystem;
        [SerializeField] protected Transform attackPoint;
        [SerializeField] protected GameObject bulletPrefab;
        [SerializeField] protected AudioSource audioSource;
        [SerializeField] protected AudioClip deathClip;

        private Enemies.Stats.BasicStats _stats;
        private float _lastAttack = 0f;

        protected virtual void OnEnable()
        {
            _stats = statsSystem.Stats;
            audioSource.loop = false;
            audioSource.playOnAwake = false;
        }

        private void Start()
        {
            GODictionary.AddVulnerableGO(gameObject, this);
        }

        public bool IsCanAttack()
        {
            return Time.time - _lastAttack >= _stats.attackSpeed;
        }

        public virtual void Attack()
        {
            if (!IsCanAttack()) return;
            _lastAttack = Time.time;

            StartCoroutine(SpawnBullet());

            anim.Attack();
        }

        protected virtual IEnumerator SpawnBullet()
        {
            for (int i = 0; i < _stats.attackTimes; i++)
            {
                Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(_stats.attackDelay);
            }
        }

        protected void PlaySound(AudioClip clip)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
        public virtual void TakeDamage(float damage)
        {
            anim.Hit();
            if (!statsSystem.TakeDamage(damage)) return;
            PlaySound(deathClip);
            anim.Death();
            Destroy(this, .2f);
        }
    }
}