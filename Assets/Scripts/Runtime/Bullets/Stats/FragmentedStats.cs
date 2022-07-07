using UnityEngine;

namespace Runtime.Bullets.Stats
{
    [CreateAssetMenu(menuName = "Stats/Bullet/Fragmented", fileName = "Fragmented Bullet Stats")]
    public class FragmentedStats : ScriptableObject
    {
        public float fragmentDistance;
    }
}