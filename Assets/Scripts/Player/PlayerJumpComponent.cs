using Collections;
using UnityEngine;

namespace Player
{
    public class PlayerJumpComponent : MonoBehaviour
    {
        [SerializeField] private float jumpHeight = 19f;

        private void Update()
        {
            if (IsPlayerStandingOnGround() || IsPlayerStandingOnLadder())
                PlayerComponentCollection.Animator.SetBool(AnimatorParameters.IsJumping, false);

            if (Input.GetButtonDown(ButtonNameCollection.Jump))
                if (IsPlayerStandingOnGround() && !IsPlayerJumping())
                    Jump();
        }
        
        private void Jump()
        {
            PlayerComponentCollection.Rigidbody2D.velocity = new Vector2(0f, jumpHeight);
            PlayerComponentCollection.Animator.SetBool(AnimatorParameters.IsJumping, true);
        }

        private static bool IsPlayerStandingOnGround() => 
            PlayerComponentCollection.FeetCollider2D.IsTouchingLayers(LayerCollection.Foreground);

        private bool IsPlayerJumping() => 
            PlayerComponentCollection.Animator.GetBool(AnimatorParameters.IsJumping);

        private bool IsPlayerStandingOnLadder() =>
            PlayerComponentCollection.FeetCollider2D.IsTouchingLayers(LayerCollection.Ladder);
    }
}