using UnityEngine;

namespace Runtime.Enemies.CombatSystems
{
    public class HugeCopterCombatSystem : BasicCombatSystem
    {
        [SerializeField] private BasicCombatSystem leftLauncher;
        [SerializeField] private BasicCombatSystem rightLauncher;
        [SerializeField] private BasicCombatSystem leftTurret;
        [SerializeField] private BasicCombatSystem rightTurret;

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
    }
}