using System;
using Runtime.Bullets.StatsSystems;
using UnityEngine;
using BasicStats = Runtime.Bullets.Stats.BasicStats;

namespace Runtime.Bullets.Behaviours
{
    public class DropBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private BasicStatsSystem statsSystem;

        private BasicStats _stats;

        private void OnEnable()
        {
            _stats = statsSystem.Stats;
        }

        private void FixedUpdate()
        {
            rb.velocity = -rb.transform.up * _stats.moveSpeed;
        }
    }
}