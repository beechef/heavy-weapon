using System.Collections.Generic;
using Runtime.Bullets.Stats;
using Runtime.Bullets.StatsSystems;
using UnityEngine;

namespace Runtime.Bullets
{
    [RequireComponent(typeof(FragmentedStatsSystem))]
    public class FragmentedBullet : BasicBullet
    {
        [SerializeField] private GameObject fragmentPrefab;
        [SerializeField] private FragmentedStatsSystem fragmentedStatsSystem;

        [SerializeField] private List<Vector3> shape = new List<Vector3>()
        {
            Vector3.up,
            Vector3.left,
            Vector3.right,
            Vector3.down + Vector3.left,
            Vector3.down + Vector3.right,
        };

        private FragmentedStats _stats;

        protected override void OnEnable()
        {
            base.OnEnable();
            _stats = fragmentedStatsSystem.Stats;
        }

        protected override void Death()
        {
            base.Death();
            CreateShape();
        }

        private void CreateShape()
        {
            Vector3 pos = transform.position;
            foreach (var piece in shape)
            {
                SpawnFragment(pos + piece * _stats.fragmentDistance);
            }
        }

        private void SpawnFragment(Vector3 pos)
        {
            Instantiate(fragmentPrefab, pos, Quaternion.identity);
        }
    }
}