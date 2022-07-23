using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Runtime.Enemies.Animations;
using Runtime.Items;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Enemies.CombatSystems
{
    public class BasicCombatSystem : CombatSystem
    {
        [SerializeField] protected BasicAnimation anim;
        [SerializeField] protected StatsSystems.BasicStatsSystem statsSystem;
        [SerializeField] protected AnimationEvents animationEvents;
        [SerializeField] protected List<string> bulletPrefabs;
        [SerializeField] protected string destroyParticlePrefab = "Destroy Particle";
        [SerializeField] protected AudioSource audioSource;
        [SerializeField] protected AudioClip deathClip;
        [SerializeField] protected Collider2D coll;
        [SerializeField] protected Pooling pooling;
        [SerializeField] protected Transform attackPoint;
        [SerializeField] protected IntVariable inGameScores;
        [SerializeField] protected GameStateSO state;
        [SerializeField] protected bool isDeadTouch = false;
        [SerializeField] protected TextRenderer textRenderer;


        protected Stats.BasicStats Stats => statsSystem.Stats;
        protected float LastAttack = 0f;
        protected bool IsDeath;
        protected bool IsHasScore;

        protected virtual void OnEnable()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {
            IsDeath = false;
            coll.enabled = true;
            audioSource.loop = false;
            audioSource.playOnAwake = false;
            EnemyPosition.AddPos(transform);
        }

        public bool isOnGameplayState()
        {
            return state.State == GameStateSO.GameState.PlayGame||state.State == GameStateSO.GameState.BossFight;
        }


        protected virtual void Awake()
        {
            GODictionary.AddVulnerableGO(gameObject, this);

            IsHasScore = inGameScores != null;

            animationEvents.OnDeath(() => { pooling.Return(gameObject, .1f).Forget(); });
        }

        public override bool IsCanAttack()
        {
            return Time.time - LastAttack >= 1f / Stats.attackSpeed && isOnGameplayState();
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


        public async virtual UniTask Death(float delay)

        {
            IsDeath = true;
            coll.enabled = false;
            PlaySound(deathClip);
            anim.Death();
            GameObject go = await pooling.GetAsync(destroyParticlePrefab, transform.position,
                Quaternion.Euler(-90f, 0f, 0f));
            pooling.Return(go, 2f).Forget();
        }

        public override void TakeDamage(float damage)
        {
            if (IsDeath) return;
            anim.Hit();
            if (!statsSystem.TakeDamage(damage)) return;
            Death(.5f);

            if (IsHasScore)
            {
                inGameScores.Value += Stats.score;
                textRenderer = Instantiate(textRenderer);
                textRenderer.Render(transform.position + transform.up, Stats.score.ToString(), 2f, false);
            }
        }

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (GODictionary.VulnerableGOs.TryGetValue(other.gameObject, out var vulnerable))
            {
                vulnerable.TakeDamage(Stats.attack);
            }

            if (other.gameObject.CompareTag(TagName.Ground) ||
                (other.gameObject.CompareTag(TagName.Player) && isDeadTouch))
                pooling.Return(gameObject, .2f).Forget();
        }

        protected virtual void OnDisable()
        {
            EnemyPosition.RemovePos(transform);
        }
    }
}