using Settings;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CapsuleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerJumpBehaviour : MonoBehaviour
    {
        [SerializeField] private float jumpHeight = 19f;
        
        private CapsuleCollider2D _feetCollider2D;
        private Rigidbody2D _myRigidbody2D;
        private Animator _animator;

        private void Start()
        {
            _feetCollider2D = GetComponent<CapsuleCollider2D>();
            _myRigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            
        }
        
        private void Update()
        {
            Jump();
        }
        
        private void Jump()
        {
            if (Input.GetButtonDown(InputButtonsNames.Jump) && 
                Layers.IsTouchingLayers(_feetCollider2D, Layers.Foreground, Layers.Ladder) &&
                !_animator.GetBool(AnimatorParameters.IsJumping))
            {
                _myRigidbody2D.velocity = new Vector2(0f, jumpHeight);
                _animator.SetBool(AnimatorParameters.IsJumping, true);
            }

            if (Layers.IsTouchingLayers(_feetCollider2D, Layers.Foreground))
            {
                _animator.SetBool(AnimatorParameters.IsJumping, false);
            }
        }
    }
}