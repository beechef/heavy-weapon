using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Enemies.CombatSystems
{
    public class BallCombatSystem : BasicCombatSystem
    {
        [Range(0, 2)] [SerializeField] private float explosionRadius;
        

        protected override async UniTask SpawnBullet()
        {
            for (int i = 0; i < Stats.attackTimes; i++)
            {
                if (bulletPrefabs.Count == 0) return;
                var randomNumber = Random.Range(0, bulletPrefabs.Count);
                GameObject go = await pooling.GetAsync(bulletPrefabs[randomNumber], attackPoint.position + RandomPos(),
                    RandomQuaternion());

                GODictionary.BasicBulletStatsSystemGOs[go].IncreaseAttack(Stats.attack);
                
                await UniTask.Delay(TimeSpan.FromSeconds(Stats.attackDelay));
            }
        }

        private Vector3 RandomPos()
        {
            return new Vector3(Random.Range(0, explosionRadius), Random.Range(0, explosionRadius), 0f);
        }

        private Quaternion RandomQuaternion()
        {
            return Quaternion.Euler(0f, 0f, Random.Range(-90f, 90f));
        }


        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(TagName.Ground))
            {
                Attack();
                return;
            }

            if (other.gameObject.CompareTag(TagName.Player) &&
                (GODictionary.VulnerableGOs.TryGetValue(other.gameObject, out var vulnerable)))
            {
                vulnerable.TakeDamage(Stats.attack);
            }
        }
    }
}