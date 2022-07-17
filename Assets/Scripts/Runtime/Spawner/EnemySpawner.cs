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

        [SerializeField] private GameStateSO state;

        private float _time;

        private void Update()
        {
            if (state.State != GameStateSO.GameState.PlayGame) return;
            for (int i = 0; i < enemyWaves.Count; i++)
            {
                EnemyWave enemyWave = enemyWaves[i];
                if (_time >= enemyWave.delayTime)
                {
                    SpawnWave(enemyWave).Forget();
                    enemyWaves.RemoveAt(i);
                    i--;
                }
            }

            _time += Time.deltaTime;
        }

        public async UniTask SpawnWave(EnemyWave enemyWave)
        {
            foreach (var enemyPack in enemyWave.enemyPacks)
            {
                for (int i = 0; i < enemyPack.quantity; i++)
                {
                    GameObject go = await spawner.GetAsync(enemyPack.enemyPrefab, enemyPack.transform.position,
                        enemyPack.transform.rotation);

                    await UniTask.Delay(TimeSpan.FromSeconds(enemyPack.delayTime));
                }

                await UniTask.Delay(TimeSpan.FromSeconds(enemyPack.delayNextPack));
            }
        }
    }
}