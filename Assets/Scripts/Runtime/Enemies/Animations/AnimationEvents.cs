using System;
using UnityEngine;

namespace Runtime.Enemies.Animations
{
    public class AnimationEvents : MonoBehaviour
    {
        private Action _onDeathActions;

        public void OnDeath(Action action)
        {
            _onDeathActions += action;
        }

        public void DeathEvent()
        {
            _onDeathActions?.Invoke();
        }
    }
}