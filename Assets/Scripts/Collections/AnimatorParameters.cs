using UnityEngine;

namespace Collections
{
    public static class AnimatorParameters
    {
        public static int IsClimbing { get; } = Animator.StringToHash(nameof(IsClimbing));
        public static int IsRunning { get; } = Animator.StringToHash(nameof(IsRunning));
        public static int IsJumping { get; } = Animator.StringToHash(nameof(IsJumping));
        public static int IsDead { get; } = Animator.StringToHash(nameof(IsDead));
        public static int IsTeleporting { get; } = Animator.StringToHash(nameof(IsTeleporting));
    }
}