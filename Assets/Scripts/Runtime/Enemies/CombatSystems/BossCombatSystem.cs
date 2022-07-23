using System;
using Cysharp.Threading.Tasks;
using Runtime.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Enemies.CombatSystems
{
    public class BossCombatSystem : BasicCombatSystem
    {
        [SerializeField] private HealthBarRenderer healthBarRenderer;
        [SerializeField] private float effectDuration = 1.5f;
        private Transform _bossHealthBar;

        protected override void Awake()
        {
            base.Awake();
            _bossHealthBar = GameObject.FindWithTag(TagName.BossHealthBar).transform;
            healthBarRenderer = Instantiate(healthBarRenderer, _bossHealthBar);
        }

        public override async UniTask Death(float delay)
        {
            IsDeath = true;
            coll.enabled = false;
            PlaySound(deathClip);
            Vector3 pos = transform.position;
            for (int i = 0; i < 35; i++)
            {
                GameObject go = await pooling.GetAsync(destroyParticlePrefab, pos + RandomVector(-2f, 2f),
                    Quaternion.Euler(-90f, 0f, 0f));
                pooling.Return(go, 2f).Forget();
                await UniTask.Delay(TimeSpan.FromSeconds(.1f));
            }

            ScreenEffects.Instance.Blink(Color.white, effectDuration);
            ScreenEffects.Instance.Shake(effectDuration);
            Destroy(gameObject, effectDuration + 0.2f);
        }

        private Vector3 RandomVector(float minValue, float maxValue)
        {
            return new Vector3(Random.Range(minValue, maxValue), Random.Range(minValue, maxValue), 0f);
        }

        public override async void TakeDamage(float damage)
        {
            if (IsDeath) return;
            anim.Hit();
            statsSystem.TakeDamage(damage);
            healthBarRenderer.Render(Stats.health, Stats.maxHealth);
            if (statsSystem.IsDead())
            {
                await Death(.5f);
                if (IsHasScore)
                    inGameScores.Value += Stats.score;
                Destroy(healthBarRenderer.gameObject, effectDuration + 0.2f);
            }
        }
    }
}