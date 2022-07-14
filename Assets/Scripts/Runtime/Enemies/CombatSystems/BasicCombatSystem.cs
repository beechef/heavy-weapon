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
        [SerializeField] protected Transform attackPoint;
        [SerializeField] protected SavedData savedData;

        protected Stats.BasicStats Stats;
        protected float LastAttack = 0f;
        protected bool IsDeath;
        private bool _issavedDataNotNull;

        private void Start()
        {
        }

        protected virtual void OnEnable()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {
            IsDeath = false;
            coll.enabled = true;
            Stats = statsSystem.Stats;
            audioSource.loop = false;
            audioSource.playOnAwake = false;
            EnemyPosition.AddPos(transform);
        }

        protected virtual void Awake()
        {
            GODictionary.AddVulnerableGO(gameObject, this);
            _issavedDataNotNull = savedData != null;
        }

        public override bool IsCanAttack()
        {
            return Time.time - LastAttack >= 1f / Stats.attackSpeed;
        }

        public override void Attack()
        {
            if (IsDeath) return;
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
                GODictionary.BasicBulletStatsSystemGOs[go].IncreaseAttack(Stats.attack);
                await UniTask.Delay(TimeSpan.FromSeconds(Stats.attackDelay));
            }
        }

        protected void PlaySound(AudioClip audioClip)
        {
            if (audioClip == null) return;
            audioSource.Stop();
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public virtual void Death(float delay)
        {
            if (_issavedDataNotNull)
                savedData.Score += Stats.score;
            IsDeath = true;
            coll.enabled = false;
            PlaySound(deathClip);
            anim.Death();
            pooling.Return(gameObject, delay).Forget();
        }

        public override void TakeDamage(float damage)
        {
            anim.Hit();
            if (!statsSystem.TakeDamage(damage)) return;
            Death(.2f);
        }

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (GODictionary.VulnerableGOs.TryGetValue(other.gameObject, out var vulnerable))
            {
                vulnerable.TakeDamage(Stats.attack);
            }

            if (other.gameObject.CompareTag(TagName.Ground) || other.gameObject.CompareTag(TagName.Player))
                pooling.Return(gameObject, .2f).Forget();
        }

        protected virtual void OnDisable()
        {
            EnemyPosition.RemovePos(transform);
        }
    }
}