using UnityEngine;

using UnityEngine.UI;


namespace Runtime.Player.Effects
{
    public class AttackSpeedEffect : Effect
    {
        private const string AttackSpeed = "AttackSpeed";
        private PlayerStatsSystem _statsSystem;


        public override string Name => AttackSpeed;


        public override bool IsEnd() => Duration <= 0f;

        public AttackSpeedEffect(PlayerStatsSystem statsSystem, float value, float maxDuration, Sprite icon)
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