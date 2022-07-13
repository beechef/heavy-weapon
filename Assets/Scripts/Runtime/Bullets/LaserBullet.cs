using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Runtime.Bullets
{
    public class LaserBullet : BasicBullet
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private LayerMask groundMask;
        Vector3 _startPoint, _endPoint;

        protected override void OnEnable()
        {
            base.OnEnable();
            CreateLaser();
            Attack();
            Death();
        }

        private void CreateLaser()
        {
            Transform cachedTransform = transform;
            _startPoint = cachedTransform.position;
            var rayCastHit = Physics2D.Raycast(_startPoint, cachedTransform.up,
                float.MaxValue, groundMask);
            
            _endPoint = rayCastHit.point;
            lineRenderer.SetPosition(0, _startPoint);
            lineRenderer.SetPosition(1, _endPoint);
        }

        protected override async void Death()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(.01f));
            base.Death();
        }

        private void Attack()
        {
            var rayCastHits = Physics2D.RaycastAll(_startPoint, transform.up);
            foreach (var rayCastHit in rayCastHits)
            {
                if (GODictionary.VulnerableGOs.TryGetValue(rayCastHit.collider.gameObject, out var vulnerable))
                {
                    vulnerable.TakeDamage(Stats.attack);
                }
            }
        }

        protected override void OnCollisionEnter2D(Collision2D other)
        {
            // Do Nothing! Laser can't taken damage
        }

        public override void TakeDamage(float damage)
        {
            // Do Nothing! Laser can't taken damage
        }
    }
}