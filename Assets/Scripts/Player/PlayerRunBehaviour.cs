using Settings;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerRunBehaviour : MonoBehaviour
    {
        [SerializeField] protected float speed = 7f;
        
        private Rigidbody2D _myRigidbody2D;
        private Animator _animator;

        private void Start()
        {
            _myRigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }
        
        private void FixedUpdate()
        {
            Run();
        }

        private void Run()
        {
            _myRigidbody2D.velocity = new Vector2(GetMovementSpeed(), _myRigidbody2D.velocity.y);
            SwitchRunningAnimation();
            SwitchLookDirection();
        }
    
        private float GetMovementSpeed() => speed * Input.GetAxis(InputAxesNames.Horizontal);
        private void SwitchRunningAnimation() => 
            _animator.SetBool(AnimatorParameters.IsRunning, GetMovementSpeed() != 0);
        private void SwitchLookDirection()
        {
            if (Mathf.Abs(GetMovementSpeed()) > 0)
                transform.localScale = new Vector2(Mathf.Sign(GetMovementSpeed()), transform.localScale.y);
        }
    }
}