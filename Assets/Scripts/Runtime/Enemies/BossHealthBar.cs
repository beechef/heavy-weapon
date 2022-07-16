using UnityEngine;

namespace Runtime.Enemy
{
    public class BossHealthBar : MonoBehaviour
    {
        [SerializeField] private Transform healthBar;

        private float _scaleX;

        private void Start()
        {
            _scaleX = healthBar.transform.localScale.x;
        }

        public void Render(float value, float maxValue)
        {
            Vector3 localScale = healthBar.transform.localScale;
            float scaleX = Mathf.Clamp(value / maxValue, 0f, 1f) * _scaleX;
            localScale.x = scaleX;
            healthBar.transform.localScale = localScale;
        }
    }
}