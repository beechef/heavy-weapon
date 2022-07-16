using System;
using Runtime.Enemies.Stats;
using Runtime.Enemies.StatsSystems;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Enemies.Behaviours
{
    public class WreckerBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private BasicStatsSystem statsSystem;
        [SerializeField] private float minMoveDistance;
        [SerializeField] private float maxMoveDistance;

        private BasicStats _stats;
        private Vector3 _startPoint;
        private Vector3 _endPoint;
        private float _time = 1f;

        sbyte _sign = -1;

        public void Stop()
        {
            enabled = false;
        }

        protected virtual void OnEnable()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {
            _stats = statsSystem.Stats;
        }

        private Vector3 RandomPosition()
        {
            _sign *= -1;
            return new Vector3(Random.Range(minMoveDistance, maxMoveDistance), 0f, 0f) * _sign;
        }

        private void FixedUpdate()
        {
            if (_time >= 1f)
            {
                _time = 0;
                _startPoint = transform.position;
                _endPoint = _startPoint + RandomPosition();
            }

            rb.MovePosition(Vector3.Lerp(_startPoint, _endPoint, _time));
            _time += _stats.moveSpeed * Time.fixedDeltaTime / 5f;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag(TagName.Wall))
            {
                _time = 1f;
            }
        }
    }
}