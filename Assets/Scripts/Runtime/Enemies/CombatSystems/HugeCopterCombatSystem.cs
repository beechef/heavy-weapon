using Cysharp.Threading.Tasks;
using Runtime.Enemies.Behaviours;
using UnityEngine;

namespace Runtime.Enemies.CombatSystems
{
    public class HugeCopterCombatSystem : BossCombatSystem
    {
        [SerializeField] private BasicCombatSystem leftLauncher;
        [SerializeField] private BasicCombatSystem rightLauncher;
        [SerializeField] private BasicCombatSystem leftTurret;
        [SerializeField] private BasicCombatSystem rightTurret;
        [SerializeField] private HugeCopterBehaviour hugeCopterBehaviour;
        private BasicCombatSystem _currentLauncher;

        protected override void Awake()
        {
            base.Awake();
            _currentLauncher = leftLauncher;
        }


        public void SwitchLauncher()
        {
            _currentLauncher = _currentLauncher == leftLauncher ? rightLauncher : leftLauncher;
        }

        public override void Attack()
        {
            if (IsDeath) return;
            _currentLauncher.Attack();

            if (Random.Range(0, 2) == 0)
            {
                leftTurret.Attack();
            }
            else
            {
                rightTurret.Attack();
            }

            anim.Attack();
        }

        public override UniTask Death(float delay)
        {
            hugeCopterBehaviour.enabled = false;
            return base.Death(delay);
        }
    }
}