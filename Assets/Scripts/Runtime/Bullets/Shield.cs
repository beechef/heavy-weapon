using UnityEngine;

namespace Runtime.Bullets
{
    public class Shield : BasicBullet
    {
        [SerializeField] private float scale = 1f;

        protected override void OnInit()
        {
            base.OnInit();
            
            Scale(scale);
        }

        public void Scale(float scale)
        {
            Transform cachedTransform = transform;
            Vector3 localScale = cachedTransform.localScale;
            localScale *= scale;
            cachedTransform.localScale = localScale;
        }
    }
}