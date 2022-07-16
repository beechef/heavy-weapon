using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Enemies.CombatSystems
{
    public class BossCombatSystem : BasicCombatSystem
    {
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

            ScreenEffects.Instance.Blink(Color.white, 1f);
            Destroy(gameObject, 1f);
        }

        private Vector3 RandomVector(float minValue, float maxValue)
        {
            return new Vector3(Random.Range(minValue, maxValue), Random.Range(minValue, maxValue), 0f);
        }
    }
}