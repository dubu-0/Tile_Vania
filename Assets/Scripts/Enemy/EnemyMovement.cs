using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PolygonCollider2D))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Walk();
        }

        public void SwitchWalkDirection()
        {
            transform.localScale *= new Vector2(-1, 1);
            speed *= -1;
        }
        
        private void Walk() => _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
    }
}
