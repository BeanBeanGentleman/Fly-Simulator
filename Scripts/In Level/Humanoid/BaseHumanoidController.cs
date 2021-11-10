using UnityEngine;

namespace In_Level.Humanoid
{
    public class BaseHumanoidController : MonoBehaviour
    {
        public Animator animator;
        public int LayerIndex;
        public Transform TargetTransform; // = BFC.transform


        public virtual void SetSwapperPos()
        {
            animator.SetIKPosition(AvatarIKGoal.RightHand, TargetTransform.transform.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, TargetTransform.transform.rotation);
        }
    }
}