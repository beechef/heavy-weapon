using System;
using System.Collections.Generic;
using Runtime.Bullets.Stats;
using Runtime.Bullets.StatsSystems;
using UnityEngine;

namespace Runtime.Bullets.Behaviours
{
    public class BounceBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private BasicStatsSystem statsSystem;

        private BasicStats _stats;
        private List<Transform> _ignoreTransform;
        private TransformData _transformData;

        private void OnEnable()
        {
            OnInit();
        }

        private void OnInit()
        {
            _stats = statsSystem.Stats;
            _ignoreTransform = new List<Transform>();
            _transformData = EnemyPosition.GetNearestEnemyPosition(transform, _ignoreTransform);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _ignoreTransform.Add(_transformData.Transform);
        }

        private void FixedUpdate()
        {
            Transform cachedTransform = transform;
            _transformData = EnemyPosition.GetNearestEnemyPosition(cachedTransform, _ignoreTransform);

            Vector3 cachedPosition = cachedTransform.position;
            Vector3 dstPosition = _transformData.Position;
            Vector3 dir = (dstPosition - cachedPosition).normalized *
                          _stats.moveSpeed;

            float rotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            cachedTransform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90f);
            rb.velocity = dir;
        }
    }
}