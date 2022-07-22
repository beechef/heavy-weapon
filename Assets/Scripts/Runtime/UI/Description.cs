using System;
using TMPro;
using UnityEngine;

namespace Runtime.UI
{
    public class Description : MonoBehaviour
    {
        [TextArea] [SerializeField] private string defaultText;
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;

        private void Awake()
        {
            RenderDefault();
        }

        public void Render(string text)
        {
            textMeshProUGUI.text = text;
        }

        public void RenderDefault()
        {
            textMeshProUGUI.text = defaultText;
        }
    }
}