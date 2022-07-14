using UnityEngine;

namespace Runtime.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] protected Animator animator;

        [SerializeField] protected string hitAnim = "Hit";
        [SerializeField] protected string deathAnim = "Death";


        public void Hit()
        {
            animator.SetTrigger(hitAnim);
        }


        public void Death()
        {
            animator.SetTrigger(deathAnim);
        }
    }
}