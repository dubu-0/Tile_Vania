using System;
using Settings;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerClimbBehaviour : MonoBehaviour
    {
        [SerializeField] protected float climbingSpeed = 9f;
        
        private BoxCollider2D _bodyCollider2D;
        private CapsuleCollider2D _feetCollider2D;
        private Rigidbody2D _myRigidbody2D;
        private Animator _animator;
        
        private float _defaultGravityScale;

        private void Start()
        {
            _bodyCollider2D = GetComponent<BoxCollider2D>();
            _feetCollider2D = GetComponent<CapsuleCollider2D>();
            _myRigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            
            _defaultGravityScale = _myRigidbody2D.gravityScale;
        }

        private void FixedUpdate()
        {
            Climb();
        }

        private void Climb()
        {
            if ((Layers.IsTouchingLayers(_bodyCollider2D, Layers.Ladder) || 
                 Layers.IsTouchingLayers(_feetCollider2D, Layers.Ladder)) && 
                !_animator.GetBool(AnimatorParameters.IsJumping))
            {
                _myRigidbody2D.velocity = new Vector2(_myRigidbody2D.velocity.x, GetClimbingSpeed());
                SetGravityScale(0f);
            }
            else
            {
                SetGravityScale(_defaultGravityScale);
            }

            PlayOrStopClimbingAnimation(IsPlayerClimbing());
        }
    
        private void SetGravityScale(float scale) => _myRigidbody2D.gravityScale = scale;
        private float GetClimbingSpeed() => climbingSpeed * Input.GetAxis(InputAxesNames.Vertical);
        private void PlayOrStopClimbingAnimation(bool b) => _animator.SetBool(AnimatorParameters.IsClimbing, b);
        private bool IsPlayerClimbing() =>
            Mathf.Abs(GetClimbingSpeed()) > 0 && Layers.IsTouchingLayers(_bodyCollider2D, Layers.Ladder);
    }
}
