using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.UI
{
    public class LauncherRenderer : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private IntVariable intVariable;
        [SerializeField] private List<Sprite> spriteLevels;

        private void Update()
        {
            image.enabled = intVariable.Value != 0;
            image.sprite = spriteLevels[Mathf.Clamp(intVariable.Value - 1, 0, spriteLevels.Count - 1)];
        }
    }
}