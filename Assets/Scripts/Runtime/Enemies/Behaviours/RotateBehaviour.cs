using Cysharp.Threading.Tasks;
using DG.Tweening;
using Runtime.Enemies.Stats;
using Runtime.Enemies.StatsSystems;
using UnityEngine;

namespace Runtime.Enemies.Behaviours
{
    public class RotateBehaviour : MonoBehaviour
    {
        [SerializeField] private BasicStatsSystem statsSystem;
        [SerializeField] private float minAngle;
        [SerializeField] private float maxAngle;

        private BasicStats _stats;
        private float _duration = 1.5f;

        private void OnEnable()
        {
            _stats = statsSystem.Stats;
        }

        private void Start()
        {
            Rotate();
        }

        private async void Rotate()
        {
            await transform.DORotateQuaternion(Quaternion.Euler(new Vector3(0f, 0f, minAngle)),
                _duration / _stats.moveSpeed).SetEase(Ease.OutSine);

            await transform.DORotateQuaternion(Quaternion.Euler(new Vector3(0f, 0f, 0f)),
                _duration / _stats.moveSpeed).SetEase(Ease.InSine);

            await transform.DORotateQuaternion(Quaternion.Euler(new Vector3(0f, 0f, maxAngle)),
                _duration / _stats.moveSpeed).SetEase(Ease.OutSine);

            await transform.DORotateQuaternion(Quaternion.Euler(new Vector3(0f, 0f, 0f)),
                _duration / _stats.moveSpeed).SetEase(Ease.InSine);
            Rotate();
        }
    }
}