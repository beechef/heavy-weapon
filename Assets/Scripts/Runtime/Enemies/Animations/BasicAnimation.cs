using UnityEngine;

namespace Runtime.Enemies.Animations
{
    public class BasicAnimation : MonoBehaviour
    {
        [SerializeField] protected Animator animator;

        [SerializeField] protected string idleAnim = "Idle";
        [SerializeField] protected string hitAnim = "Hit";
        [SerializeField] protected string moveForwardAnim = "MoveForward";
        [SerializeField] protected string attackAnim = "Attack";
        [SerializeField] protected string deathAnim = "Death";

        public Animator GetAnimator() => animator;

        public virtual void Idle()
        {
            animator.SetTrigger(idleAnim);
        }

        public virtual void Hit()
        {
            animator.SetTrigger(hitAnim);
        }

        public virtual void MoveForward()
        {
            animator.SetTrigger(moveForwardAnim);
        }

        public virtual void Attack()
        {
            animator.SetTrigger(attackAnim);
        }

        public virtual void Death()
        {
            animator.SetTrigger(deathAnim);
        }
    }
}