using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Bullets
{
    public class FragmentedBullet : BasicBullet
    {
        [SerializeField] private string fragmentPrefab;

        [SerializeField] private List<Vector2> shape = new List<Vector2>()
        {
            Vector2.up,
            Vector2.left,
            Vector2.right,
            Vector2.down + Vector2.left,
            Vector2.down + Vector2.right,
        }; // Star Shape


        protected override void Death()
        {
            base.Death();
            CreateShape();
        }

        private void CreateShape()
        {
            foreach (var piece in shape)
            {
                SpawnFragment(piece);
            }
        }

        private async void SpawnFragment(Vector2 dir)
        {
            float rotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            GameObject go = await pooling.GetAsync(fragmentPrefab, transform.position,
                Quaternion.Euler(0f, 0f, rotationZ - 90f));

            GODictionary.BasicBulletStatsSystemGOs[go].IncreaseAttack(Stats.attack);
        }
    }
}