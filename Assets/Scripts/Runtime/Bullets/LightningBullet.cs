using System.Collections.Generic;
using Runtime.Interfaces;
using UnityEngine;

namespace Runtime.Bullets
{
    public class LightningBullet : BasicBullet
    {
        private List<IVulnerable> _vulnerables;

        protected override void OnEnable()
        {
            base.OnEnable();
            _vulnerables = new List<IVulnerable>();
        }

        protected override void OnCollision(Collider2D other)
        {
            if (GODictionary.VulnerableGOs.TryGetValue(other.gameObject, out var vulnerable))
            {
                if (_vulnerables.Contains(vulnerable)) return;
                _vulnerables.Add(vulnerable);
                vulnerable.TakeDamage(Stats.attack);
            }
        }

        protected override void OnCollisionEnter2D(Collision2D other)
        {
            OnCollision(other.collider);
            if (other.gameObject.CompareTag(TagName.Ground))
                Death();
        }

        public override void TakeDamage(float damage)
        {
            // Do Nothing! Lightning can't taken damage
        }
    }
}