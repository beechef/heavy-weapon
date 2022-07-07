using Runtime.Enemies.Animations;
using Runtime.Enemies.CombatSystems;
using Runtime.Enemies.Controllers;
using Runtime.Enemies.Stats;
using Runtime.Enemies.StatsSystems;
using UnityEngine;

namespace Runtime.Enemies.Behaviours
{
    public class BasicBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private BasicAnimation anim;
        [SerializeField] private BasicCombatSystem combatSystem;
        [SerializeField] private BasicStatsSystem statsSystem;
        
        private BasicStats _stats;

        protected virtual void OnEnable()
        {
            _stats = statsSystem.Stats;
        }

        protected virtual void Update()
        {
            if (combatSystem.IsCanAttack())
            {
                BasicController.Attack(combatSystem);
            }
            else
            {
                BasicController.MoveForward(rb, _stats, anim);
            }
        }
    }
}