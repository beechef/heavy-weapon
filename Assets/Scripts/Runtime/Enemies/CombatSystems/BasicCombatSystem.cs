using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Runtime.Enemies.Animations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Enemies.CombatSystems
{
    [RequireComponent(typeof(Collider2D))]
    public class BasicCombatSystem : CombatSystem
    {
        [SerializeField] protected BasicAnimation anim;
        [SerializeField] protected StatsSystems.BasicStatsSystem statsSystem;
        [SerializeField] protected Transform attackPoint;
        [SerializeField] protected List<GameObject> bulletPrefabs;
        [SerializeField] protected AudioSource audioSource;
        [SerializeField] protected AudioClip deathClip;
        [SerializeField] protected Collider2D coll;

        private Stats.BasicStats _stats;
        private float _lastAttack = 0f;

        protected virtual void OnEnable()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {
            coll.enabled = true;
            _stats = statsSystem.Stats;
            audioSource.loop = false;
            audioSource.playOnAwake = false;
        }

        private void Start()
        {
            GODictionary.AddVulnerableGO(gameObject, this);
        }

        public override bool IsCanAttack()
        {
            return Time.time - _lastAttack >= _stats.attackSpeed;
        }

        public override void Attack()
        {
            if (!IsCanAttack()) return;
            _lastAttack = Time.time;

            SpawnBullet().Forget();

            anim.Attack();
        }

        protected virtual async UniTask SpawnBullet()
        {
            for (int i = 0; i < _stats.attackTimes; i++)
            {
                if (bulletPrefabs.Count == 0) return;
                var randomNumber = Random.Range(0, bulletPrefabs.Count);
                GameObject go = bulletPrefabs[randomNumber];
                Instantiate(go, attackPoint.position, Quaternion.identity);
                await UniTask.Delay(TimeSpan.FromSeconds(_stats.attackDelay));
            }
        }

        protected void PlaySound(AudioClip clip)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }

        protected virtual void Death()
        {
            coll.enabled = false;
            PlaySound(deathClip);
            anim.Death();
            Destroy(gameObject, .2f);
        }

        public override void TakeDamage(float damage)
        {
            anim.Hit();
            if (!statsSystem.TakeDamage(damage)) return;
            Death();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject, .2f);
        }
    }
}