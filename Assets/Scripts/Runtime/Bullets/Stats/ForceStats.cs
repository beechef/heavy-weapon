using UnityEngine;

namespace Runtime.Bullets.Stats
{
    [CreateAssetMenu(menuName = "Stats/Bullet/Force", fileName = "Force Bullet Stats")]
    public class ForceStats : BasicStats
    {
        public float force;
    }
}