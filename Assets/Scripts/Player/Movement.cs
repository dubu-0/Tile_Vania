using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator), 
        typeof(SpriteRenderer))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        private const string Horizontal = nameof(Horizontal);
        private static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
        
        private Rigidbody2D _rigidbody2D;
        private Transform _transform;
        private Animator _animator;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = transform;
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Run();
        }

        private void Run()
        {
            _rigidbody2D.velocity = new Vector2(GetMovementSpeed(), _rigidbody2D.velocity.y);
            SwitchAnimation();
            SwitchLookDirection();
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
