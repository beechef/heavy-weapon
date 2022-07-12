using Runtime.Enemies.CombatSystems;
using Runtime.Enemies.Stats;
using Runtime.Enemies.StatsSystems;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Enemies.Behaviours
{
    public class HugeCopterBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private BasicStatsSystem statsSystem;
        [SerializeField] private HugeCopterCombatSystem combatSystem;

        [SerializeField] private float minMoveDistance;
        [SerializeField] private float maxMoveDistance;
        [SerializeField] private float timeSwitchLauncher;
        private BasicStats _stats;
        private Vector2 _moveDir;
        private float _timeMove;
        private Vector2 _startPoint;
        private Vector2 _endPoint;
        private Vector2 _heightPoint;
        private float _curveHeight;
        private float _lastSwitchLauncher;

        private void OnEnable()
        {
            OnInit();
        }

        private void FixedUpdate()
        {
            Move();
            SwitchLauncher();
            Attack();
        }

        private void OnInit()
        {
            _stats = statsSystem.Stats;
            _moveDir = Vector2.right;
            Vector2 pos = transform.position;
            SetPoint(pos + _moveDir * RandomMoveDistance(), 2.5f);
        }

        private void SwitchLauncher()
        {
            if (Time.time - _lastSwitchLauncher < timeSwitchLauncher) return;
            _lastSwitchLauncher = Time.time;
            combatSystem.SwitchLauncher();
        }

        private void Attack()
        {
            combatSystem.Attack();
        }

        private float RandomMoveDistance() => Random.Range(minMoveDistance, maxMoveDistance);

        private void Move()
        {
            if (_timeMove >= 1f)
            {
                Vector2 pos = transform.position;
                _moveDir = -_moveDir;
                SetPoint(pos + _moveDir * RandomMoveDistance(), 2.5f);
            }

            _timeMove += Time.fixedDeltaTime * _stats.moveSpeed / 5f;
            rb.MovePosition(GetNextPosition(_timeMove));
        }

        private Vector2 GetHeightPoint()
        {
            Vector2 heightPoint = Vector2.Lerp(_endPoint, _startPoint, .5f);
            heightPoint += Vector2.down * _curveHeight;
            return heightPoint;
        }

        private void SetPoint(Vector3 point, float curveHeight)
        {
            _startPoint = transform.position;
            _endPoint = point;
            _curveHeight = curveHeight;
            _timeMove = 0f;

            _heightPoint = GetHeightPoint();
        }

        private Vector2 GetNextPosition(float time)
        {
            Vector2 pointA = Vector2.Lerp(_startPoint, _heightPoint, time);
            Vector2 pointB = Vector2.Lerp(_heightPoint, _endPoint, time);
            Vector2 nextPosition = Vector2.Lerp(pointA, pointB, time);

            return nextPosition;
        }
    }
}