using UnityEngine;
using UnityEngine.UI;

namespace Runtime.UI
{
    public class AdjustSound : MonoBehaviour
    {
        [SerializeField] private FloatVariable floatVariable;
        [SerializeField] private Slider slider;

        private void Awake()
        {
            slider.value = floatVariable.Value;
        }

        public void ChangeValue(float value)
        {
            floatVariable.Value = value;
        }
    }
}