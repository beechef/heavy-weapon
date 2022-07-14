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
        [SerializeField] private bool isTracePlayer = true;

        private BasicStats _stats;

        private void OnEnable()
        {
            OnInit();
        }

        private void OnInit()
        {
            _stats = statsSystem.Stats;
        }

        private void FixedUpdate()
        {
            Transform cachedTransform = transform;
            Vector3 cachedPosition = cachedTransform.position;
            Vector3 dstPosition = isTracePlayer
                ? PlayerPosition.GetNearestPlayerPosition(cachedTransform)
                : EnemyPosition.GetNearestEnemyPosition(cachedTransform, null).Position;
            Vector3 dir = (dstPosition - cachedPosition).normalized *
                          _stats.moveSpeed;
            float rotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            cachedTransform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90f);
            rb.velocity = dir;
        }
    }
}