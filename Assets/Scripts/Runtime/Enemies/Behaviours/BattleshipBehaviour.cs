using Runtime.Enemies.CombatSystems;
using Runtime.Enemies.StatsSystems;
using UnityEngine;

namespace Runtime.Enemies.Behaviours
{
    public class BattleshipBehaviour : MonoBehaviour
    {
        [SerializeField] private BasicStatsSystem statsSystem;
        [SerializeField] private BattleshipCombatSystem combatSystem;

        private void Update()
        {
            combatSystem.Attack();
        }
    }
}