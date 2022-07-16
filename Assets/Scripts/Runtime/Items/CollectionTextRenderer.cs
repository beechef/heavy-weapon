using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Items
{
    public class CollectionTextRenderer : MonoBehaviour
    {
        [SerializeField] private TextMeshPro textMeshPro;


        public void Render(Vector3 pos, string text, float time)
        {
            transform.position = pos;
            textMeshPro.text = text;
            Blink(time);
        }

        private async void Blink(float time)
        {
            int loopTimes = 10;
            float timeStep = time / loopTimes;
            for (int i = loopTimes; i >= 0; i--)
            {
                textMeshPro.color = Random.ColorHSV(0f, .25f, 1f, 1f,
                    1f, 1f, i * 1.0f / loopTimes, i * 1.0f / loopTimes);

                await UniTask.Delay(TimeSpan.FromSeconds(timeStep));
            }

            Destroy(gameObject);
        }
    }
}