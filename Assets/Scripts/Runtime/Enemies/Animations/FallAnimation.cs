using UnityEngine;

namespace Runtime.Enemies.Animations
{
    public class FallAnimation : BasicAnimation
    {
        [SerializeField] protected string fallAnim = "Fall";

        public virtual void Fall()
        {
            animator.SetTrigger(fallAnim);
        }
    }
}