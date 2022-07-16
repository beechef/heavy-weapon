using Runtime.Player;
using Runtime.Player.Effects;
using UnityEngine;

namespace Runtime.Items
{
    public class AttackSpeedItem : Item
    {
        [SerializeField] private Sprite icon;
        [SerializeField] private float value;
        [SerializeField] private float duration;

        public override void Collect(GameObject go)
        {
            PlayerStatsSystem statsSystem = GODictionary.PlayerStatsSystems[go];
            EffectManager effectManager = GODictionary.PlayerEffectManagers[go];

            effectManager.Add(new AttackSpeedEffect(statsSystem, value, duration, icon), EffectType.Replace);
        }
        protected override string GetCollectionText() => $"Power Up: +{value} Attack Speed in {duration}s";


    }
}