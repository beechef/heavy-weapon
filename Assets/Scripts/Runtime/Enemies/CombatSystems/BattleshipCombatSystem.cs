using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Enemies.CombatSystems
{
    public class BattleshipCombatSystem : BasicCombatSystem
    {
        [SerializeField] private List<GunCombatSystem> guns;

        public override void Attack()
        {
            if (!IsCanAttack()) return;
            if (guns.Count <= 0) return;
            int randomNumber = Random.Range(0, guns.Count);
            GunCombatSystem gun = guns[randomNumber];
            gun.Attack();
            LastAttack = Time.time;
        }
    }
}