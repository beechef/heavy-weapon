﻿using Runtime.Interfaces;
using UnityEngine;

namespace Runtime.Items
{
    public abstract class Item : MonoBehaviour, ICollectable
    {
        [SerializeField] private CollectionTextRenderer textRendererRenderer;
        public abstract void Collect(GameObject go);

        protected abstract string GetCollectionText();

        public void OnCollisionEnter2D(Collision2D other)
        {
            GameObject go = other.gameObject;
            if (go.CompareTag(TagName.Player))
            {
                Collect(go);
                Destroy(gameObject);
                textRendererRenderer = Instantiate(textRendererRenderer);
                textRendererRenderer.Render(transform.position + Vector3.up * 2f, GetCollectionText(), 1.5f);
            }

            if (go.CompareTag(TagName.Enemy))
            {
                Destroy(gameObject);
            }
        }
    }
}