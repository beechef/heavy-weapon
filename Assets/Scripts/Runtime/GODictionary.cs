using System.Collections.Generic;
using Runtime.Interfaces;
using Runtime.Player;
using Runtime.Player.Effects;
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

        public static Dictionary<GameObject, PlayerStatsSystem> PlayerStatsSystems { get; private set; }
        public static Dictionary<GameObject, EffectManager> PlayerEffectManagers { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initial()
        {
            VulnerableGOs = new Dictionary<GameObject, IVulnerable>();
            BasicEnemyStatsSystemGOs = new Dictionary<GameObject, Enemies.StatsSystems.BasicStatsSystem>();
            BasicBulletStatsSystemGOs = new Dictionary<GameObject, Bullets.StatsSystems.BasicStatsSystem>();
            PlayerStatsSystems = new Dictionary<GameObject, PlayerStatsSystem>();
            PlayerEffectManagers = new Dictionary<GameObject, EffectManager>();
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

        public static void AddPlayerStatsSystem(GameObject key, PlayerStatsSystem stats)
        {
            PlayerStatsSystems.Add(key, stats);
        }

        public static void RemovePlayerStatsSystem(GameObject key)
        {
            PlayerStatsSystems.Remove(key);
        }

        public static void AddEffectManager(GameObject key, EffectManager stats)
        {
            PlayerEffectManagers.Add(key, stats);
        }

        public static void RemoveEffectManager(GameObject key)
        {
            PlayerEffectManagers.Remove(key);
        }
    }
}