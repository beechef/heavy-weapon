using UnityEngine;

namespace Runtime.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerCombatSystem playerCombatSystem;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Attack();
            }
        }

        private void Attack()
        {
            playerCombatSystem.Attack();
        }
    }
}