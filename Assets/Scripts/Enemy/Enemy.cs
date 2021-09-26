using Interfaces;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int damagePoints = 1;

        private void OnCollisionEnter2D(Collision2D other)
        {
            other.gameObject.GetComponent<Player.Player>()?.KickPlayer();
            other.gameObject.GetComponent<IDamageReceiver>()?.TakeDamage(damagePoints);
        }
    }
}
