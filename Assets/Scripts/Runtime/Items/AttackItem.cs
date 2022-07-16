using Runtime.Player;
using Runtime.Player.Effects;
using UnityEngine;

namespace Runtime.Items
{
    public class AttackItem : Item
    {
        [SerializeField] private Sprite icon;
        [SerializeField] private float value;
        [SerializeField] private float duration;

        public override void Collect(GameObject go)
        {
            PlayerStatsSystem statsSystem = GODictionary.PlayerStatsSystems[go];
            EffectManager effectManager = GODictionary.PlayerEffectManagers[go];

            effectManager.Add(new AttackEffect(statsSystem, value, duration, icon), EffectType.Replace);
        }

        protected override string GetCollectionText() => $"Power Up: +{value} Attack in {duration}s";
    }
}