using System;
using UnityEngine;

namespace Runtime.Bullets
{
    public class LaserBullet : BasicBullet
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private LayerMask enemyMask;
        private Vector3 _startPoint, _endPoint;
        private float _lastAttack;

        private float _timeAudio;

        protected override void Awake()
        {
            base.Awake();
            audioSource.loop = true;
            audioSource.clip = startClip;
            audioSource.Play();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            audioSource.time = _timeAudio;
        }

        private void FixedUpdate()
        {
            Attack();
        }

        private void OnDisable()
        {
            _timeAudio = audioSource.time;
        }

        protected override void OnInit()
        {
        }

        private void CreateLaser()
        {
            Transform cachedTransform = transform;
            _startPoint = cachedTransform.position;
            var rayCastHit = Physics2D.Raycast(_startPoint, cachedTransform.up,
                float.MaxValue, groundMask);
            _endPoint = rayCastHit.point;
            _startPoint.z = -1;
            _endPoint.z = -1;
            lineRenderer.SetPosition(0, _startPoint);
            lineRenderer.SetPosition(1, _endPoint);
        }

        protected override void Death()
        {
        }

        public void Attack()
        {
            CreateLaser();
            if (Time.time - _lastAttack <= 1f / Stats.attackSpeed) return;
            _lastAttack = Time.time;
            var rayCastHits = Physics2D.BoxCastAll(_startPoint, Vector2.one / 2f, 0f, transform.up,
                float.MaxValue, enemyMask);
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