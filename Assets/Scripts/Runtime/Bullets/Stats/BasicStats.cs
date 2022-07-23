using UnityEngine;

namespace Runtime.Bullets.Stats
{
    [CreateAssetMenu(menuName = "Stats/Bullet/Basic", fileName = "Basic Bullet Stats")]
    public class BasicStats : ScriptableObject
    {
        public float attack;
        public float attackSpeed;
        [HideInInspector] public float health;
        public float maxHealth;
        public float moveSpeed;
        public int score;
    }
}