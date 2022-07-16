using UnityEngine;

using UnityEngine.UI;


namespace Runtime.Player.Effects
{
    public class SpeedUpEffect : Effect
    {
        private const string SpeedUp = "SpeedUp";
        private PlayerStatsSystem _statsSystem;


        public override string Name => SpeedUp;


        public override bool IsEnd() => Duration <= 0f;

        public SpeedUpEffect(PlayerStatsSystem statsSystem, float value, float maxDuration, Sprite icon)
        {
            _statsSystem = statsSystem;
            Value = value;
            Duration = maxDuration;
            MaxDuration = maxDuration;
            Icon = icon;
        }

        public override void OnStart()
        {
            _statsSystem.Stats.moveSpeed += Value;
        }

        public override void OnUpdate()
        {
            Duration -= Time.deltaTime;
        }

        public override void OnEnd()
        {
            _statsSystem.Stats.moveSpeed -= Value;
        }
    }
}