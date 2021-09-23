using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed = 7f;
        [SerializeField] private float jumpHeight = 19f;

        private const string Horizontal = nameof(Horizontal);
        private const string Jump = nameof(Jump);
        private const string Foreground = nameof(Foreground);
        private static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
        private static readonly int IsClimbing = Animator.StringToHash(nameof(IsClimbing));

        private Rigidbody2D _rigidbody2D;
        private Transform _transform;
        private Animator _animator;
        private CapsuleCollider2D _collider2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = transform;
            _animator = GetComponent<Animator>();
            _collider2D = GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            Run();
            
            if (Input.GetButtonDown(Jump) && _collider2D.IsTouchingLayers(LayerMask.GetMask(Foreground)))
                JumpOnce();
        }

        private void Run()
        {
            _rigidbody2D.velocity = new Vector2(GetMovementSpeed(), _rigidbody2D.velocity.y);
            SwitchAnimation();
            SwitchLookDirection();
        }

        private void JumpOnce()
        {
            _rigidbody2D.velocity += new Vector2(0f, jumpHeight);
        }

        private void SwitchAnimation() => _animator.SetBool(IsRunning, GetMovementSpeed() != 0);
        private float GetMovementSpeed() => speed * Input.GetAxis(Horizontal);
        private void SwitchLookDirection()
        {
            if (Mathf.Abs(GetMovementSpeed()) > 0)
                _transform.localScale = new Vector2(Mathf.Sign(GetMovementSpeed()), _transform.localScale.y);
        }
    }
}
