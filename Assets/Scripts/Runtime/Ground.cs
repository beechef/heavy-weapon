using System;
using UnityEngine;

namespace Runtime
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private GameObject fireStreakPrefab;
        [SerializeField] private string particlePrefab;
        [SerializeField] private Pooling pooling;

        private async void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag(TagName.FireStreak) && !other.gameObject.CompareTag(TagName.Enemy)) return;
            Vector3 pos = other.GetContact(0).point;
            Instantiate(fireStreakPrefab, pos, Quaternion.identity).transform.parent = transform;
            GameObject go = await pooling.GetAsync(particlePrefab, pos, Quaternion.Euler(-90f, 0f, 0f));
            var parent = go.transform.parent;
            var cachedParent = parent;
            go.transform.parent = transform;
            await pooling.Return(go, 2f);
            parent = cachedParent;
            go.transform.parent = parent;
        }

        private void OnDisable()
        {
            var cachedTransform = transform;
            for (int i = 0; i < cachedTransform.childCount; i++)
            {
                Destroy(cachedTransform.GetChild(i).gameObject);
            }
        }
    }
}