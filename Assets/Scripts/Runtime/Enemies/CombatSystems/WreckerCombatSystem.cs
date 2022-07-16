using Cysharp.Threading.Tasks;
using Runtime.Enemies.Behaviours;
using UnityEngine;

namespace Runtime.Enemies.CombatSystems
{
    public class WreckerCombatSystem : BossCombatSystem
    {
        [SerializeField] private BallCombatSystem ballCombatSystem;
        [SerializeField] private WreckerBehaviour wreckerBehaviour;

        public override async UniTask Death(float delay)
        {
            wreckerBehaviour.Stop();
            ballCombatSystem.Stop();
            await base.Death(delay);
            Destroy(transform.parent.gameObject, 1f);
        }
    }
}