using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update() => Walk();
        
        // Triggers when enemy reaches the end of the ground
        private void OnTriggerExit2D(Collider2D other) => SwitchWalkDirection();
        
        private void Walk() => _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
        private void SwitchWalkDirection()
        {
            transform.localScale *= new Vector2(-1, 1);
            speed *= -1;
        }
    }
}
