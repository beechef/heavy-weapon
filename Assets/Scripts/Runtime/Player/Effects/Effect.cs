using Runtime.Interfaces;
using UnityEngine;

namespace Runtime.Player.Effects
{
    public abstract class Effect : IEffect
    {
        public Sprite Icon;
        public float Value;
        public float Duration;
        public float MaxDuration;
        public abstract string Name { get; }
        public abstract bool IsEnd();

        public abstract void OnStart();

        public abstract void OnUpdate();

        public abstract void OnEnd();
    }
}