using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class Movement : MonoBehaviour
    {
        [Header("Player Settings")]
        [SerializeField] private float speed = 7f;
        [SerializeField] private float climbingSpeed = 9f;
        [SerializeField] private float jumpHeight = 19f;

        private const string Horizontal = nameof(Horizontal);
        private const string Vertical = nameof(Vertical);
        private const string Jump = nameof(Jump);
        private const string Foreground = nameof(Foreground);
        private const string Ladder = nameof(Ladder);
        private static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
        private static readonly int IsClimbing = Animator.StringToHash(nameof(IsClimbing));

        private Rigidbody2D _rigidbody2D;
        private Transform _transform;
        private Animator _animator;
        private CapsuleCollider2D _collider2D;

        private float _defaultGravityScale;
        private bool _isJumping = false;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = transform;
            _animator = GetComponent<Animator>();
            _collider2D = GetComponent<CapsuleCollider2D>();

            _defaultGravityScale = _rigidbody2D.gravityScale;
        }

        private void Update()
        {
            Run();
            JumpOnce();
            Climb();
        }

        private void Run()
        {
            _rigidbody2D.velocity = new Vector2(GetMovementSpeed(), _rigidbody2D.velocity.y);
            SwitchRunningAnimation();
            SwitchLookDirection();
        }

        private void JumpOnce()
        {
            if (Input.GetButtonDown(Jump) && IsTouchingLayers(Foreground, Ladder))
            {
                _rigidbody2D.velocity += new Vector2(0f, jumpHeight);
                _isJumping = true;
            }

            if (IsTouchingLayers(Foreground))
            {
                _isJumping = false;
            }
        }

        private void Climb()
        {
            if (IsTouchingLayers(Ladder) && !_isJumping)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, GetClimbingSpeed());
                SetGravityScale(0f);
            }
            else
            {
                SetGravityScale(_defaultGravityScale);
            }

            PlayOrStopClimbingAnimation(Mathf.Abs(GetClimbingSpeed()) > 0 && IsTouchingLayers(Ladder));
        }

        private bool IsTouchingLayers(params string[] names)
        {
            foreach (var layerName in names)
            {
                if (_collider2D.IsTouchingLayers(LayerMask.GetMask(layerName)))
                {
                    return true;
                }
            }

            return false;
        }
        private void SwitchRunningAnimation() => _animator.SetBool(IsRunning, GetMovementSpeed() != 0);
        private void PlayOrStopClimbingAnimation(bool b) => _animator.SetBool(IsClimbing, b);
        private float GetMovementSpeed() => speed * Input.GetAxis(Horizontal);
        private float GetClimbingSpeed() => climbingSpeed * Input.GetAxis(Vertical);
        private void SetGravityScale(float scale) => _rigidbody2D.gravityScale = scale;
        private void SwitchLookDirection()
        {
            if (Mathf.Abs(GetMovementSpeed()) > 0)
                _transform.localScale = new Vector2(Mathf.Sign(GetMovementSpeed()), _transform.localScale.y);
        }
    }
}
