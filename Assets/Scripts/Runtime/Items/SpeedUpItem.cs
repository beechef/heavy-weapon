using Runtime.Player;
using Runtime.Player.Effects;
using UnityEngine;

namespace Runtime.Items
{
    public class SpeedUpItem : Item
    {
        [SerializeField] private Sprite icon;
        [SerializeField] private float value;
        [SerializeField] private float duration;

        public override void Collect(GameObject go)
        {
            PlayerStatsSystem statsSystem = GODictionary.PlayerStatsSystems[go];
            EffectManager effectManager = GODictionary.PlayerEffectManagers[go];

            effectManager.Add(new SpeedUpEffect(statsSystem, value, duration, icon), EffectType.Replace);
        }

        protected override string GetCollectionText() => $"Speed Up: +{value} Move Speed in {duration}s";
    }
}