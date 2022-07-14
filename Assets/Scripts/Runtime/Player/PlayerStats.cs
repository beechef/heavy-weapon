using UnityEngine;

namespace Runtime.Player
{
    [CreateAssetMenu]
    public class PlayerStats : ScriptableObject
    {
        public float attack;
        public float attackSpeed;
        public float moveSpeed;
        public int amountAttackPoint = 1;
        [HideInInspector] public float health;
        public float maxHealth;
        public int lives = 3;
    }
}