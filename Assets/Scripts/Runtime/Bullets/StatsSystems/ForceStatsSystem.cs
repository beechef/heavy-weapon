using Runtime.Bullets.Stats;
using UnityEngine;

namespace Runtime.Bullets.StatsSystems
{
    public class ForceStatsSystem : BasicStatsSystem
    {
        [SerializeField] protected ForceStats forceStats;
        public ForceStats ForceStats => forceStats;
    }
}