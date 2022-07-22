using System;
using System.Collections.Generic;
using Runtime.Bullets.Stats;
using Runtime.Bullets.StatsSystems;
using UnityEngine;

namespace Runtime.Player
{
    public class ShieldController : MonoBehaviour
    {
        [SerializeField] private GameObject shield;
        [SerializeField] private IntVariable level;
        [SerializeField] private BasicStatsSystem statsSystem;

        [SerializeField] private List<float> moveSpeedLevelSheet = new List<float>()
        {
            0, 1, 2, 3, 4
        };

        private BasicStats Stats => statsSystem.Stats;

        private void OnEnable()
        {
            if (level.Value == 0) return;
            shield.SetActive(true);
        }
        

        public void Init()
        {
            var index = Mathf.Clamp(this.level.Value, 0, moveSpeedLevelSheet.Count);
            Stats.moveSpeed += moveSpeedLevelSheet[index];
        }
    }
}