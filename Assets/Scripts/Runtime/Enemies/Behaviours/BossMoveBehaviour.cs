using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Enemies.Behaviours
{
    public class BossMoveBehaviour : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> behaviours;
        [SerializeField] private float moveSpeed;

        private Vector3 _bossPoint;
        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;

            _bossPoint = GameObject.FindWithTag(TagName.BossPoint).transform.position;

            SetEnableCombatSystems(false);
        }

        private void Update()
        {
            var position = _cachedTransform.position;
            if (Vector3.Distance(position, _bossPoint) <= 0.1f)
            {
                SetEnableCombatSystems(true);
                enabled = false;
                return;
            }

            Vector3 dir = (_bossPoint - position).normalized;

            position += dir * (moveSpeed * Time.deltaTime);
            _cachedTransform.position = position;
        }

        private void SetEnableCombatSystems(bool isEnable)
        {
            foreach (var behaviour in behaviours)
            {
                behaviour.enabled = isEnable;
            }
        }
    }
}