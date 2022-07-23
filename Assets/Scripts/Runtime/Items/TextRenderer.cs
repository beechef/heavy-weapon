using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Items
{
    public class TextRenderer : MonoBehaviour
    {
        [SerializeField] private TextMeshPro textMeshPro;


        public void Render(Vector3 pos, string text, float time, bool isBlink = true)
        {
            transform.position = pos;
            textMeshPro.text = text;
            Blink(time, isBlink);
        }

        private async void Blink(float time, bool isBlink)
        {
            int loopTimes = 10;
            float timeStep = time / loopTimes;
            for (int i = loopTimes; i >= 0; i--)
            {
                Color color = isBlink
                    ? Random.ColorHSV(0f, .25f, 1f, 1f,
                        1f, 1f, i * 1.0f / loopTimes, i * 1.0f / loopTimes)
                    : new Color(1, 1, 1, i * 1.0f / loopTimes);
                
                textMeshPro.color = color;

                await UniTask.Delay(TimeSpan.FromSeconds(timeStep));
            }

            Destroy(gameObject);
        }
    }
}