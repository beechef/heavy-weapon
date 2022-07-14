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
        [SerializeField] protected List<string> bulletPrefabs;
        [SerializeField] protected AudioSource audioSource;
        [SerializeField] protected AudioClip deathClip;
        [SerializeField] protected Collider2D coll;
        [SerializeField] protected Pooling pooling;
        [SerializeField] public Transform attackPoint;

        protected Stats.BasicStats Stats;
        protected float LastAttack = 0f;

        protected virtual void OnEnable()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {
            coll.enabled = true;
            Stats = statsSystem.Stats;
            audioSource.loop = false;
            audioSource.playOnAwake = false;
        }

        protected virtual void Start()
        {
            GODictionary.AddVulnerableGO(gameObject, this);
        }

        public override bool IsCanAttack()
        {
            return Time.time - LastAttack >= Stats.attackSpeed;
        }

        public override void Attack()
        {
            if (!IsCanAttack()) return;
            LastAttack = Time.time;

            SpawnBullet().Forget();

            anim.Attack();
        }

        protected virtual async UniTask SpawnBullet()
        {
            for (int i = 0; i < Stats.attackTimes; i++)
            {
                if (bulletPrefabs.Count == 0) return;
                var randomNumber = Random.Range(0, bulletPrefabs.Count);
                GameObject go = await pooling.GetAsync(bulletPrefabs[randomNumber], attackPoint.position,
                    attackPoint.rotation);
                await UniTask.Delay(TimeSpan.FromSeconds(Stats.attackDelay));
            }
        }

        protected void PlaySound(AudioClip clip)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }

        public virtual void Death()
        {
            coll.enabled = false;
            PlaySound(deathClip);
            anim.Death();
            pooling.Return(gameObject, .2f).Forget();
        }

        public override void TakeDamage(float damage)
        {
            anim.Hit();
            if (!statsSystem.TakeDamage(damage)) return;
            Death();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(TagName.Ground))
                pooling.Return(gameObject, .2f).Forget();
        }
    }
}