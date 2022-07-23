using UnityEngine;

namespace Runtime.Enemy
{
    public class HealthBarRenderer : MonoBehaviour
    {
        [SerializeField] private Transform healthBar;
        
        public void Render(float value, float maxValue)
        {
            Vector3 localScale = healthBar.transform.localScale;
            float scaleX = Mathf.Clamp(value / maxValue, 0f, 1f);
            localScale.x = scaleX;
            healthBar.transform.localScale = localScale;
        }
    }
}