using Runtime.Enemies.Animations;
using Runtime.Enemies.CombatSystems;
using Runtime.Enemies.Stats;
using UnityEngine;

namespace Runtime.Enemies.Controllers
{
    public static class BasicController
    {
        public static void MoveForward(Rigidbody2D rb, BasicStats stats, BasicAnimation anim)
        {
            rb.velocity = rb.transform.right * stats.moveSpeed;
            anim.MoveForward();
        }

        public static void Attack(BasicCombatSystem combatSystem)
        {
            combatSystem.Attack();
        }
    }
}