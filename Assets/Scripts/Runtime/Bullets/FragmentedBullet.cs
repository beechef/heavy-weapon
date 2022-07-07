using Runtime.Bullets.Stats;
using Runtime.Bullets.StatsSystems;
using Runtime.Enemies.Stats;
using Runtime.Enemies.StatsSystems;
using UnityEngine;

namespace Runtime.Bullets
{
    [RequireComponent(typeof(FragmentedStatsSystem))]
    public class FragmentedBullet : BasicBullet
    {
        [SerializeField] private GameObject fragmentPrefab;
        [SerializeField] private FragmentedStatsSystem fragmentedStatsSystem;
        private FragmentedStats _stats;

        protected override void OnEnable()
        {
            base.OnEnable();
            _stats = fragmentedStatsSystem.FragmentedStatsStats;
        }

        protected override void Death()
        {
            base.Death();
            Vector3 pos = transform.position;
            SpawnFragment(pos + Vector3.up * _stats.fragmentDistance);
            SpawnFragment(pos + Vector3.down * _stats.fragmentDistance);
            SpawnFragment(pos + Vector3.left * _stats.fragmentDistance);
            SpawnFragment(pos + Vector3.right * _stats.fragmentDistance);
        }

        private void SpawnFragment(Vector3 pos)
        {
            Instantiate(fragmentPrefab, pos, Quaternion.identity);
        }
    }
}