using TMPro;
using UnityEngine;

namespace Runtime.UI
{
    public class IntRenderer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;
        [SerializeField] private IntVariable intVariable;

        private void Awake()
        {
            Render(intVariable.Value);
            intVariable.OnChange += Render;
        }

        private void Render(int value)
        {
            textMeshProUGUI.text = value.ToString();
        }
    }
}