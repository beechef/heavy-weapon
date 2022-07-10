using Runtime.Bullets.Stats;
using Runtime.Bullets.StatsSystems;
using Runtime.Enemy;
using UnityEngine;

namespace Runtime.Bullets.Behaviours
{
    public class MoveToPointBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private BasicStatsSystem statsSystem;
        [SerializeField] private LayerMask groundLayer;

        private BasicStats _stats;
        private Vector2 _startPoint;
        private Vector2 _endPoint;
        private Vector2 _heightPoint;
        private bool _hasCurve;
        private float _curveHeight;
        private float _time = 1f;

        private void OnEnable()
        {
            _stats = statsSystem.Stats;
            SetPoint(PlayerPosition.GetNearestPlayerPosition(transform.position), Random.Range(0, 1) == 0, 5f);
        }

        private void RotateToDir(Vector2 dir)
        {
            float rotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 90f);
        }

        public void SetPoint(Vector2 point, bool hasCurve, float curveHeight)
        {
            _startPoint = transform.position;
            _endPoint = point;
            _hasCurve = hasCurve;
            _curveHeight = curveHeight;
            _time = 0f;
            Vector2 dir = (_endPoint - _startPoint).normalized;
            RotateToDir(dir);
            _heightPoint = GetHeightPoint(dir);
            if (IsImpactGround()) _heightPoint = GetHeightPoint(-dir);
        }

        private Vector2 GetHeightPoint(Vector2 dir)
        {
            Vector2 normalVector = Vector2.zero;
            normalVector.x = -dir.y;
            normalVector.y = dir.x;
            Vector2 heightPoint = Vector2.Lerp(_endPoint, _startPoint, .5f);
            heightPoint += normalVector * _curveHeight;
            return heightPoint;
        }

        private bool IsImpactGround()
        {
            float time = 0f;
            while (time < 1f)
            {
                Vector2 movePoint = GetNextPosition(time);
                time += _stats.moveSpeed * Time.fixedDeltaTime / 5f;
                Collider2D col = Physics2D.OverlapPoint(movePoint, groundLayer);
                if (col != null)
                {
                    return true;
                }
            }

            return false;
        }

        private Vector2 GetNextPosition(float time)
        {
            Vector2 nextPosition;
            if (_hasCurve)
            {
                Vector2 pointA = Vector2.Lerp(_startPoint, _heightPoint, time);
                Vector2 pointB = Vector2.Lerp(_heightPoint, _endPoint, time);
                nextPosition = Vector2.Lerp(pointA, pointB, time);
            }
            else
            {
                nextPosition = Vector2.Lerp(_startPoint, _endPoint, time);
            }

            return nextPosition;
        }

        private void FixedUpdate()
        {
            if (_time >= 1f) return;
            Vector2 nextPosition = GetNextPosition(_time);
            Vector2 currentPosition = transform.position;
            Vector2 dir = nextPosition - currentPosition;
            RotateToDir(dir);
            rb.MovePosition(nextPosition);
            _time += _stats.moveSpeed * Time.fixedDeltaTime / 5f;
        }
    }
}