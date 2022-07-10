using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Bullets
{
    public class FragmentedBullet : BasicBullet
    {
        [SerializeField] private GameObject fragmentPrefab;

        [SerializeField] private List<Vector2> shape = new List<Vector2>()
        {
            Vector2.up,
            Vector2.left,
            Vector2.right,
            Vector2.down + Vector2.left,
            Vector2.down + Vector2.right,
        };


        protected override void Death()
        {
            base.Death();
            CreateShape();
        }

        private void CreateShape()
        {
            Vector2 pos = transform.position;
            foreach (var piece in shape)
            {
                SpawnFragment(piece);
            }
        }

        private void SpawnFragment(Vector2 dir)
        {
            GameObject go = Instantiate(fragmentPrefab, transform.position, Quaternion.identity);
            float rotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            go.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90f);
        }
    }
}