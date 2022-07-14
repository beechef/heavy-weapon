using UnityEngine;

namespace Runtime.Spawner
{
    [System.Serializable]
    public class EnemyPack
    {
        public string enemyPrefab;
        public int quantity;
        public float delayTime;
        public float delayNextPack;
        public Transform transform;
        public Direction direction;
    }

    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
}