using System;
using Collections;
using UnityEngine;

namespace Player
{
    public class PlayerRunComponent : MonoBehaviour
    {
        [SerializeField] protected float speed = 7f;

        private Vector2 _lookDirection = new Vector2(1, 1);
        
        private void LateUpdate()
        {
            Run();
        }

        private void Run()
        {
            PlayerComponentCollection.Rigidbody2D.velocity = 
                new Vector2(GetMovementSpeed(), PlayerComponentCollection.Rigidbody2D.velocity.y);
            SwitchRunningAnimation();
            SwitchLookDirection();
        }

        private float GetMovementSpeed() => speed * Input.GetAxis(AxisNameCollection.Horizontal);
        private void SwitchRunningAnimation() => 
            PlayerComponentCollection.Animator.SetBool(
                AnimatorParameters.IsRunning, GetMovementSpeed() != 0);
        private void SwitchLookDirection()
        {
            if (Mathf.Abs(GetMovementSpeed()) > 0)
            {
                _lookDirection = new Vector2(Mathf.Sign(GetMovementSpeed()), transform.localScale.y);
            }
            
            transform.localScale = _lookDirection;
        }
    }
}