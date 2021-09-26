using Settings;
using UnityEngine;

namespace Player
{
    public class PlayerRunComponent : MonoBehaviour
    {
        [SerializeField] protected float speed = 7f;

        private void FixedUpdate()
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
                AnimatorParameterCollection.IsRunning, GetMovementSpeed() != 0);
        private void SwitchLookDirection()
        {
            if (Mathf.Abs(GetMovementSpeed()) > 0)
                transform.localScale = new Vector2(Mathf.Sign(GetMovementSpeed()), transform.localScale.y);
        }
    }
}