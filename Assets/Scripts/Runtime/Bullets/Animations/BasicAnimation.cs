using UnityEngine;

namespace Runtime.Bullets.Animations
{
    public class BasicAnimation : MonoBehaviour
    {
        [SerializeField] protected Animator animator;

        [SerializeField] protected string moveForwardAnim = "MoveForward";
        [SerializeField] protected string hitAnim = "Hit";
        [SerializeField] protected string deathAnim = "Death";

        public virtual void MoveForward()
        {
            animator.SetTrigger(moveForwardAnim);
        }

        public virtual void Death()
        {
            animator.SetTrigger(deathAnim);
        }

        public virtual void Hit()
        {
            animator.SetTrigger(hitAnim);
        }
    }
}