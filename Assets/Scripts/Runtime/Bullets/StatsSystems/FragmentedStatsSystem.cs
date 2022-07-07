using Runtime.Bullets.Stats;
using UnityEngine;

namespace Runtime.Bullets.StatsSystems
{
    public class FragmentedStatsSystem : BasicStatsSystem
    {
        [SerializeField] protected FragmentedStats fragmentedStats;
        public FragmentedStats FragmentedStatsStats => fragmentedStats;

    }
}