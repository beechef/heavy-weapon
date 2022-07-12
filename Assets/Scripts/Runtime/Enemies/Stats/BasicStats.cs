using UnityEngine;

namespace Runtime.Enemies.Stats
{
    [CreateAssetMenu(menuName = "Stats/Enemy/Basic", fileName = "Enemy Basic Stats"), System.Serializable]
    public class BasicStats : ScriptableObject
    {
        public float attack;
        public float health;
        public float maxHealth;
        public float attackTimes;
        public float attackDelay;
        public float attackSpeed;
        public float moveSpeed;
    }
}