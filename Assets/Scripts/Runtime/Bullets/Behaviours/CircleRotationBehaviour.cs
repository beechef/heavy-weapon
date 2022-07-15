using Runtime.Bullets.Stats;
using Runtime.Bullets.StatsSystems;
using UnityEngine;

namespace Runtime.Bullets.Behaviours
{
    public class CircleRotationBehaviour : MonoBehaviour
    {
        [SerializeField] private BasicStatsSystem statsSystem;

        private BasicStats _stats;

        private void OnEnable()
        {
            _stats = statsSystem.Stats;
        }

        private void FixedUpdate()
        {
            transform.Rotate(new Vector3(0f, 0f, _stats.moveSpeed * Time.fixedDeltaTime * 50f), Space.Self);
        }
    }
}