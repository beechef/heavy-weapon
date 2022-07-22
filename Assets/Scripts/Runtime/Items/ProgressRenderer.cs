using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Items
{
    public class ProgressRenderer : MonoBehaviour
    {
        [SerializeField] private Image filledImage;

        public void Render(float value, float maxValue)
        {
            filledImage.fillAmount = value / maxValue;
        }
    }
}