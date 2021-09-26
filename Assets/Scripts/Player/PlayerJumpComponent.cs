using Settings;
using UnityEngine;

namespace Player
{
    public class PlayerJumpComponent : MonoBehaviour
    {
        [SerializeField] private float jumpHeight = 19f;

        private void Update()
        {
            if (IsPlayerStandingOnGround())
                PlayerComponentCollection.Animator.SetBool(AnimatorParameterCollection.IsJumping, false);

            if (Input.GetButtonDown(ButtonNameCollection.Jump))
                if ((IsPlayerStandingOnLadder() || IsPlayerStandingOnGround()) && !IsPlayerJumping())
                    Jump();
        }
        
        private void Jump()
        {
            PlayerComponentCollection.Rigidbody2D.velocity = new Vector2(0f, jumpHeight);
            PlayerComponentCollection.Animator.SetBool(AnimatorParameterCollection.IsJumping, true);
        }

        private static bool IsPlayerStandingOnGround() => 
            PlayerComponentCollection.FeetCollider2D.IsTouchingLayers(LayerCollection.Foreground);

        private bool IsPlayerJumping() => 
            PlayerComponentCollection.Animator.GetBool(AnimatorParameterCollection.IsJumping);

        private bool IsPlayerStandingOnLadder() =>
            PlayerComponentCollection.FeetCollider2D.IsTouchingLayers(LayerCollection.Ladder);
    }
}