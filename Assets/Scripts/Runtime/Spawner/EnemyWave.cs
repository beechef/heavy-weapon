using System.Collections.Generic;

namespace Runtime.Spawner
{
    [System.Serializable]
    public class EnemyWave
    {
        public List<EnemyPack> enemyPacks;
        public float delayTime;
    }
}