using UnityEngine;
using UnityEngine.UI;

namespace Runtime.UI
{
    public class LauncherRenderer : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private IntVariable intVariable;

        private void Update()
        {
            image.enabled = intVariable.Value != 0;
        }
    }
}