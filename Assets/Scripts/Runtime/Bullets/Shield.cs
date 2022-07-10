using UnityEngine;

namespace Runtime.Bullets
{
    public class Shield : BasicBullet
    {
        [SerializeField] private new SpriteRenderer renderer;
        [SerializeField] private float scale = 1f;
        [SerializeField] private bool isPlayOnAwake = true;

        protected override void OnInit()
        {
            base.OnInit();
            if (isPlayOnAwake)
            {
                TurnOn();
            }

            Scale(scale);
        }

        public void Scale(float scale)
        {
            Transform cachedTransform = transform;
            Vector3 localScale = cachedTransform.localScale;
            localScale *= scale;
            cachedTransform.localScale = localScale;
        }

        public void TurnOn()
        {
            renderer.enabled = true;
            coll.enabled = true;
        }

        public void TurnOff()
        {
            renderer.enabled = false;
            coll.enabled = false;
        }

        private void OnDisable()
        {
            TurnOff();
        }
    }
}