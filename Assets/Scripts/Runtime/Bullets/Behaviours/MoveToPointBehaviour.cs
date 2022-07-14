using Runtime.Bullets.Stats;
using Runtime.Bullets.StatsSystems;
using Runtime.Enemy;
using UnityEngine;

namespace Runtime.Bullets.Behaviours
{
    public class MoveToPointBehaviour : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] protected BasicStatsSystem statsSystem;
        [SerializeField] protected LayerMask groundLayer;
        [SerializeField] protected Vector2 size;
        [SerializeField] protected bool hasCurve;
        protected BasicStats Stats;
        protected Vector2 StartPoint;
        protected Vector2 EndPoint;
        protected Vector2 HeightPoint;
        protected float CurveHeight;
        protected float Time = 1f;


        protected virtual void OnEnable()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {
            Stats = statsSystem.Stats;
            SetPoint(PlayerPosition.GetNearestPlayerPosition(transform), 1.5f);
        }

        protected virtual void RotateToDir(Vector2 dir)
        {
            float rotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 90f);
        }

        public void SetPoint(Vector2 point, float curveHeight)
        {
            StartPoint = transform.position;
            EndPoint = point;
            CurveHeight = curveHeight;
            Time = 0f;
            Vector2 dir = (EndPoint - StartPoint).normalized;
            RotateToDir(dir);
            if (!hasCurve)
            {
                HeightPoint = EndPoint;
                return;
            }

            HeightPoint = GetHeightPoint(dir);
            if (IsImpactGround()) HeightPoint = GetHeightPoint(-dir);
            if (IsImpactGround()) HeightPoint = point;
        }

        protected virtual Vector2 GetHeightPoint(Vector2 dir)
        {
            Vector2 normalVector = Vector2.zero;
            normalVector.x = -dir.y;
            normalVector.y = dir.x;
            Vector2 heightPoint = Vector2.Lerp(EndPoint, StartPoint, .5f);
            heightPoint += normalVector * CurveHeight;
            return heightPoint;
        }

        protected virtual bool IsImpactGround()
        {
            float time = 0f;
            while (time < 1f)
            {
                Vector2 movePoint = GetNextPosition(time);
                time += UnityEngine.Time.fixedDeltaTime / 5f;
                Collider2D col = Physics2D.OverlapBox(movePoint, size, 0f, groundLayer);
                if (col != null)
                {
                    return true;
                }
            }

            return false;
        }

        protected virtual Vector2 GetNextPosition(float time)
        {
            Vector2 pointA = Vector2.Lerp(StartPoint, HeightPoint, time);
            Vector2 pointB = Vector2.Lerp(HeightPoint, EndPoint, time);
            var nextPosition = Vector2.Lerp(pointA, pointB, time);

            return nextPosition;
        }

        protected virtual void FixedUpdate()
        {
            if (Time >= 1f) return;
            Vector2 nextPosition = GetNextPosition(Time);
            Vector2 currentPosition = transform.position;
            Vector2 dir = nextPosition - currentPosition;
            RotateToDir(dir);
            rb.MovePosition(nextPosition);
            Time += Stats.moveSpeed * UnityEngine.Time.fixedDeltaTime / 5f;
        }
    }
}