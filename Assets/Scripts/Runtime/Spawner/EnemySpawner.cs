using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Runtime.Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyWave> enemyWaves;
        private EnemyWave _currentWave;
        private float _currentDelay;
        private float _lastSpawn;

        private void OnEnable()
        {
            _lastSpawn = Time.time;
            _currentWave = GetNextWave();
        }

        private void Update()
        {
            if (_currentWave == null) return;
            if (Time.time - _lastSpawn >= _currentDelay)
            {
                SpawnWave().Forget();
                _currentDelay = _currentWave.delayTime;
                _currentWave = GetNextWave();
                _lastSpawn = Time.time;
            }
        }

        private EnemyWave GetNextWave()
        {
            if (enemyWaves.Count == 0) return null;
            EnemyWave enemyWave = enemyWaves[0];
            enemyWaves.RemoveAt(0);
            return enemyWave;
        }

        public async UniTask SpawnWave()
        {
            if (_currentWave == null) return;
            var enemyWave = _currentWave;
            foreach (var enemyPack in enemyWave.enemyPacks)
            {
                for (int i = 0; i < enemyPack.quantity; i++)
                {
                    GameObject go = Instantiate(enemyPack.enemyPrefab);
                    Transform cachedTransform = go.transform;
                    cachedTransform.position = enemyPack.transform.position;

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