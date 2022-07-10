using UnityEngine;

namespace Runtime.Spawner
{
    [System.Serializable]
    public class EnemyPack
    {
        public GameObject enemyPrefab;
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