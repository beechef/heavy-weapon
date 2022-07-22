using Runtime.Player;
using UnityEngine;

namespace Runtime.Items
{
    public class MegaLaserItem : Item
    {
        [SerializeField] private float value;

        public override void Collect(GameObject go)
        {
            PlayerStatsSystem statsSystem = GODictionary.PlayerStatsSystems[go];
            statsSystem.Stats.megaLaserComplete += value;
        }

        protected override string GetCollectionText() => "Mega Laser Complete 25%";
    }
}