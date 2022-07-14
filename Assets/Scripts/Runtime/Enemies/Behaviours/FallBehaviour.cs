using System;
using Cysharp.Threading.Tasks;
using Runtime.Enemies.Animations;
using Runtime.Enemies.Stats;
using Runtime.Enemies.StatsSystems;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Enemies.Behaviours
{
    public class FallBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private BasicStatsSystem statsSystem;
        [SerializeField] private FallAnimation fallAnimation;
        [SerializeField] private float minFallTime;
        [SerializeField] private float maxFallTime;

        private BasicStats _stats;
        private Vector3 _dir;
        private float _fallTime;

        private void OnEnable()
        {
            _stats = statsSystem.Stats;
            _dir = transform.right;
            _fallTime = Random.Range(minFallTime, maxFallTime);
            ChangeDir();
        }

        private void FixedUpdate()
        {
            rb.velocity = _dir * _stats.moveSpeed;
        }

        private async void ChangeDir()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_fallTime));
            _dir = -transform.up;
            fallAnimation.Fall();
        }
    }
}