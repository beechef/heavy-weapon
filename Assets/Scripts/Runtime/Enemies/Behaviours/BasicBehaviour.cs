using Runtime.Enemies.Animations;
using Runtime.Enemies.CombatSystems;
using Runtime.Enemies.Stats;
using Runtime.Enemies.StatsSystems;
using UnityEngine;

namespace Runtime.Enemies.Behaviours
{
    public class BasicBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private BasicAnimation anim;
        [SerializeField] private CombatSystem combatSystem;
        [SerializeField] private BasicStatsSystem statsSystem;

        private BasicStats _stats;

        protected virtual void OnEnable()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {
            _stats = statsSystem.Stats;
        }

        protected virtual void FixedUpdate()
        {
            if (combatSystem.IsCanAttack())
            {
                Attack();
            }
            else
            {
                MoveForward();
            }
        }

        private void MoveForward()
        {
            rb.velocity = rb.transform.right * _stats.moveSpeed;
            anim.MoveForward();
        }

        private void Attack()
        {
            combatSystem.Attack();
        }
    }
}