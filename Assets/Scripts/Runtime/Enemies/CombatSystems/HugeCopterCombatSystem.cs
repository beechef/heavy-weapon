using Runtime.Enemies.StatsSystems;
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

        protected override void Start()
        {
            base.Start();
            _currentLauncher = leftLauncher;
        }


        public void SwitchLauncher()
        {
            _currentLauncher = _currentLauncher == leftLauncher ? rightLauncher : leftLauncher;
        }

        public override void Attack()
        {
            if (_currentLauncher.IsCanAttack())
            {
                _currentLauncher.Attack();

                anim.Attack();
            }

            if (leftTurret.IsCanAttack())
            {
                leftTurret.Attack();
            }

            if (rightTurret.IsCanAttack())
            {
                rightTurret.Attack();
            }
        }


        public override void TakeDamage(float damage)
        {
            anim.Hit();
            if (!statsSystem.TakeDamage(damage)) return;

            Death();
        }
    }
}