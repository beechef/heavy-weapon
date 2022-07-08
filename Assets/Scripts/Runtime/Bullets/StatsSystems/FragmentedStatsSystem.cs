using Runtime.Bullets.Stats;
using UnityEngine;

namespace Runtime.Bullets.StatsSystems
{
    public class FragmentedStatsSystem : BasicStatsSystem
    {
        public new FragmentedStats Stats => stats as FragmentedStats;
    }
}