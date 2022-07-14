using Runtime.Bullets.Stats;
using Runtime.Bullets.StatsSystems;
using UnityEngine;

namespace Runtime.Bullets.Behaviours
{
    public class ForceBehaviour : MonoBehaviour
    {
        private const float ForcePower = 50f;
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] private BasicStatsSystem statsSystem;

        private BasicStats _stats;

        protected virtual void OnEnable()
        {
            OnInit();
        }

        private void OnInit()
        {
            _stats = statsSystem.Stats;
            if (rb.isKinematic)
                rb.velocity = transform.up * _stats.moveSpeed;
            else
                rb.AddForce(transform.up * _stats.moveSpeed * ForcePower, ForceMode2D.Force);
        }
    }
}