using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Player
{
    public class SpreadController : MonoBehaviour
    {
        [SerializeField] private IntVariable level;
        [SerializeField] private PlayerStatsSystem statsSystem;

        [SerializeField] private List<int> levelSheet = new List<int>()
        {
            0, 1, 2, 3, 4
        };

        private PlayerStats Stats => statsSystem.Stats;

        private void Init()
        {
            var index = Mathf.Clamp(level.value, 0, levelSheet.Count);
            Stats.amountAttackPoint += levelSheet[index];
        }

        private void Awake()
        {
            statsSystem.OnInit += Init;
        }
    }
}