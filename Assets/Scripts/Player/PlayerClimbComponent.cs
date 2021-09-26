using System;
using Settings;
using UnityEngine;

namespace Player
{
    public class PlayerClimbComponent : MonoBehaviour
    {
        [SerializeField] protected float climbingSpeed = 9f;
        
        private float _defaultGravityScale;

        private void Start()
        {
            _defaultGravityScale = PlayerComponentCollection.Rigidbody2D.gravityScale;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsPlayerTouchingLadder())
            {
                Climb();
            }
            else
            {
                PlayerComponentCollection.Rigidbody2D.gravityScale = _defaultGravityScale;
            }
        }

        private void Climb()
        {
            PlayerComponentCollection.Rigidbody2D.velocity =
                new Vector2(PlayerComponentCollection.Rigidbody2D.velocity.x, GetClimbingSpeed());
            
            PlayerComponentCollection.Rigidbody2D.gravityScale = 0f;
            PlayerComponentCollection.Animator.SetBool(AnimatorParameterCollection.IsClimbing, IsPlayerClimbing());
        }

        private bool IsPlayerJumping() => 
            PlayerComponentCollection.Animator.GetBool(AnimatorParameterCollection.IsJumping);

        private bool IsPlayerTouchingLadder() =>
            (PlayerComponentCollection.BodyCollider2D.IsTouchingLayers(LayerCollection.Ladder) ||
             PlayerComponentCollection.FeetCollider2D.IsTouchingLayers(LayerCollection.Ladder)) &&
            !IsPlayerJumping();

        private float GetClimbingSpeed() => climbingSpeed * Input.GetAxis(AxisNameCollection.Vertical);

        private bool IsPlayerClimbing() =>
            Mathf.Abs(GetClimbingSpeed()) > 0 && IsPlayerTouchingLadder();
    }
}
