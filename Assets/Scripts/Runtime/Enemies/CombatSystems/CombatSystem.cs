using Runtime.Interfaces;
using UnityEngine;

namespace Runtime.Enemies.CombatSystems
{
    public abstract class CombatSystem : MonoBehaviour, IAttackable, IVulnerable
    {
        public abstract bool IsCanAttack();

        public abstract void Attack();
        
        public abstract void TakeDamage(float damage);
    }
}