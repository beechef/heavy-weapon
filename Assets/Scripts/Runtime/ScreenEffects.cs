using UnityEngine;
using UnityEngine.UI;

namespace Runtime
{
    public class ScreenEffects : MonoBehaviour
    {
        public static ScreenEffects Instance { get; private set; }

        [SerializeField] private Image image;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance);
            }

            Instance = this;
        }

        public void Blink(Color color, float time)
        {
            image.color = color;
            image.CrossFadeAlpha(0f, time, false);
        }
    }
}