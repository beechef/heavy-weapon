using Runtime.Player;
using UnityEngine;

namespace Runtime.Items
{
    public class MegaLaserItem : Item
    {
        [SerializeField] private float value;

        public override void Collect(GameObject go)
        {
            PlayerStats stats = GODictionary.PlayerStatsSystems[go].Stats;
            stats.megaLaserComplete += value;
        }

        protected override string GetCollectionText() => "Mega Laser Complete 25%";
    }
}