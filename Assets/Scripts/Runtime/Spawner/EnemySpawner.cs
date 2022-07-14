using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets.Pooling;

namespace Runtime.Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyWave> enemyWaves;

        [SerializeField] private Pooling spawner;

        private void Update()
        {
            for (int i = 0; i < enemyWaves.Count; i++)
            {
                EnemyWave enemyWave = enemyWaves[i];
                if (Time.time >= enemyWave.delayTime)
                {
                    SpawnWave(enemyWave).Forget();
                    enemyWaves.RemoveAt(i);
                    i--;
                }
            }
        }

        public async UniTask SpawnWave(EnemyWave enemyWave)
        {
            foreach (var enemyPack in enemyWave.enemyPacks)
            {
                for (int i = 0; i < enemyPack.quantity; i++)
                {
                    GameObject go = await spawner.GetAsync(enemyPack.enemyPrefab, enemyPack.transform.position,
                        Quaternion.identity);
                    Transform cachedTransform = go.transform;

                    switch (enemyPack.direction)
                    {
                        case Direction.Left:
                        {
                            cachedTransform.Rotate(Vector3.up * 180);
                            break;
                        }
                        case Direction.Right:
                        {
                            break;
                        }
                        case Direction.Up:
                        {
                            cachedTransform.Rotate(Vector3.forward * 180);
                            break;
                        }
                        case Direction.Down:
                        {
                            cachedTransform.Rotate(Vector3.back * 180);
                            break;
                        }
                    }

                    await UniTask.Delay(TimeSpan.FromSeconds(enemyPack.delayTime));
                }

                await UniTask.Delay(TimeSpan.FromSeconds(enemyPack.delayNextPack));
            }
        }
    }
}