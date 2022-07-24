using UnityEngine;

namespace Runtime.UI
{
    public class Exit : MonoBehaviour
    {
        public void QuitApplication()
        {
            Application.Quit();
        }
    }
}