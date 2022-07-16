using Runtime.Player;
using UnityEngine;

namespace Runtime.Items
{
    public class SpreadItem : Item
    {
        [SerializeField] private int value = 1;

        public override void Collect(GameObject go)
        {
            PlayerStats stats = GODictionary.PlayerStatsSystems[go].Stats;
            stats.amountAttackPoint += value;
        }

        protected override string GetCollectionText() => $"Power Up: +{value} Attack Point";
    }
}