
﻿using DG.Tweening;
using UnityEngine;

using UnityEngine.UI;

namespace Runtime
{
    public class ScreenEffects : MonoBehaviour
    {
        public static ScreenEffects Instance { get; private set; }

        [SerializeField] private Image image;

        private Camera _camera;


        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance);
            }

            Instance = this;

            _camera = Camera.main;

        }

        public void Blink(Color color, float time)
        {
            image.color = color;
            image.CrossFadeAlpha(0f, time, false);
        }


        public void Shake(float duration, float strength = 5f)
        {
            _camera.DOShakeRotation(duration, strength);
        }

    }
}