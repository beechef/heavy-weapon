using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class AnimateLineRenderer : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private List<Sprite> sprites;
        [SerializeField] private float timeBetween;

        private List<Texture> _textures;
        private float _time;
        private int _currentIndex;

        private void Start()
        {
            _textures = new List<Texture>();
            foreach (var sprite in sprites)
            {
                _textures.Add(SpriteToTexture(sprite));
            }
        }

        private void Update()
        {
            if (_textures.Count <= 0) return;
            if (_time >= timeBetween)
            {
                _time = 0f;
                _currentIndex = GetNextIndex(_currentIndex);
                lineRenderer.material.SetTexture("_MainTex", _textures[_currentIndex]);
            }

            _time += Time.deltaTime;
        }

        private Texture2D SpriteToTexture(Sprite sprite)
        {
            var texture = new Texture2D((int) sprite.rect.width, (int) sprite.rect.height);
            var pixels = sprite.texture.GetPixels((int) sprite.textureRect.x,
                (int) sprite.textureRect.y,
                texture.width,
                texture.height);
            texture.SetPixels(pixels);
            texture.Apply();
            return texture;
        }

        private int GetNextIndex(int index)
        {
            return index + 1 < _textures.Count ? index + 1 : 0;
        }
    }
}