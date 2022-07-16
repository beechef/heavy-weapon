using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Enemies.CombatSystems
{
    public class BattleshipCombatSystem : BasicCombatSystem
    {
        [SerializeField] private List<GunCombatSystem> guns;
        [SerializeField] private List<BasicCombatSystem> launchers;

        public override void Attack()
        {
            if (!IsCanAttack()) return;
            LastAttack = Time.time;

            if (guns.Count <= 0) return;
            int randomNumber = Random.Range(0, guns.Count);
            GunCombatSystem gun = guns[randomNumber];
            gun.Attack();
            if (launchers.Count <= 0) return;
            randomNumber = Random.Range(0, launchers.Count);
            BasicCombatSystem launcher = launchers[randomNumber];
            launcher.Attack();
        }
    }
}