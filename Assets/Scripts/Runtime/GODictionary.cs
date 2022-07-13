using System.Collections.Generic;
using Runtime.Interfaces;
using UnityEngine;

namespace Runtime
{
    public static class GODictionary
    {
        public static Dictionary<GameObject, IVulnerable> VulnerableGOs { get; private set; }

        public static Dictionary<GameObject, Enemies.StatsSystems.BasicStatsSystem> BasicEnemyStatsSystemGOs
        {
            get;
            private set;
        }

        public static Dictionary<GameObject, Bullets.StatsSystems.BasicStatsSystem> BasicBulletStatsSystemGOs
        {
            get;
            private set;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initial()
        {
            VulnerableGOs = new Dictionary<GameObject, IVulnerable>();
            BasicEnemyStatsSystemGOs = new Dictionary<GameObject, Enemies.StatsSystems.BasicStatsSystem>();
            BasicBulletStatsSystemGOs = new Dictionary<GameObject, Bullets.StatsSystems.BasicStatsSystem>();
        }

        public static void AddVulnerableGO(GameObject key, IVulnerable vulnerable)
        {
            VulnerableGOs.Add(key, vulnerable);
        }

        public static void RemoveVulnerableGO(GameObject key)
        {
            VulnerableGOs.Remove(key);
        }

        public static void AddBasicEnemyStatsSystemGO(GameObject key,
            Enemies.StatsSystems.BasicStatsSystem basicStatsSystem)
        {
            BasicEnemyStatsSystemGOs.Add(key, basicStatsSystem);
        }

        public static void RemoveBasicEnemyStatsSystemGO(GameObject key)
        {
            BasicEnemyStatsSystemGOs.Remove(key);
        }

        public static void AddBasicBulletStatsSystemGO(GameObject key,
            Bullets.StatsSystems.BasicStatsSystem basicStatsSystem)
        {
            BasicBulletStatsSystemGOs.Add(key, basicStatsSystem);
        }

        public static void RemoveBasicBulletStatsSystemGO(GameObject key)
        {
            BasicBulletStatsSystemGOs.Remove(key);
        }
    }
}