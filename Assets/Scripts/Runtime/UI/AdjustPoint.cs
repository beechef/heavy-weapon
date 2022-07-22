using UnityEngine;

namespace Runtime.UI
{
    public class AdjustPoint : MonoBehaviour
    {
        [SerializeField] private int point;
        [SerializeField] private int maxPoint = 4;
        [SerializeField] private IntVariable pointsRemaining;
        [SerializeField] private IntVariable targetPoint;

        public void Adjust()
        {
            var pointsRemainingValue = pointsRemaining.Value;
            var targetValue = targetPoint.Value;

            if (pointsRemainingValue - point < 0) return;
            if (targetValue + point < 0 || targetValue + point > maxPoint) return;

            targetValue += point;
            pointsRemainingValue -= point;

            targetPoint.Value = targetValue;
            pointsRemaining.Value = pointsRemainingValue;
        }
    }
}