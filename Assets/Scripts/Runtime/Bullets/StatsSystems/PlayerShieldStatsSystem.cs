using Runtime.Player;
using UnityEngine;

namespace Runtime.Bullets.StatsSystems
{
    public class PlayerShieldStatsSystem : BasicStatsSystem
    {
        [SerializeField] private ShieldController shieldController;

        protected override void OnInit()
        {
            base.OnInit();
            shieldController.Init();
        }
    }
}