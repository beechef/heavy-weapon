using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Player.Effects
{
    public class EffectRenderer : MonoBehaviour
    {
        public Image icon;
        public Image filled;
        public TextMeshProUGUI txtDuration;

        public void Render(float value, float maxValue)
        {
            filled.fillAmount = (maxValue - value) / maxValue;
            txtDuration.text = $"{Math.Round(value, 1)}s";
        }
    }
}