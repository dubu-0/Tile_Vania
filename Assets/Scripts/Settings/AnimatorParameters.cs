using UnityEngine;

namespace Settings
{
    public class AnimatorParameters : ScriptableObject
    {
        public static int IsClimbing => Animator.StringToHash(nameof(IsClimbing));
        public static int IsRunning => Animator.StringToHash(nameof(IsRunning));
        public static int IsJumping => Animator.StringToHash(nameof(IsJumping));
        public static int IsDead => Animator.StringToHash(nameof(IsDead));
    }
}