using Runtime.Bullets.StatsSystems;
using Runtime.Enemy;
using UnityEngine;
using BasicStats = Runtime.Bullets.Stats.BasicStats;

namespace Runtime.Bullets.Behaviours
{
    public class TraceBehaviour : MonoBehaviour
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
            Vector3 cachedPosition = transform.position;
            Vector3 playerPosition = PlayerPosition.GetNearestPlayerPosition(cachedPosition);
            Vector3 dir = (playerPosition - cachedPosition).normalized *
                          _stats.moveSpeed;
            float rotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 90f);
            rb.velocity = dir;
        }
    }
}