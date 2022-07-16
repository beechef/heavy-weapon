using UnityEngine;

namespace Runtime.Player.Effects
{
    public class AttackEffect : Effect
    {
        private const string Attack = "Attack";
        private PlayerStatsSystem _statsSystem;

        public override string Name => Attack;


        public override bool IsEnd() => Duration <= 0f;

        public AttackEffect(PlayerStatsSystem statsSystem, float value, float maxDuration, Sprite icon)
        {
            _statsSystem = statsSystem;
            Value = value;
            Duration = maxDuration;
            MaxDuration = maxDuration;
            Icon = icon;
        }

        public override void OnStart()
        {
            _statsSystem.Stats.attackSpeed += Value;
        }

        public override void OnUpdate()
        {
            Duration -= Time.deltaTime;
        }

        public override void OnEnd()
        {
            _statsSystem.Stats.attackSpeed -= Value;
        }
    }
}