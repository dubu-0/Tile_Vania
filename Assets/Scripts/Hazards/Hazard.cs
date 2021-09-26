using Interfaces;
using UnityEngine;

namespace Hazards
{
    public class Hazard : MonoBehaviour
    {
        [SerializeField] private int damagePoints = 1;

        private void OnCollisionEnter2D(Collision2D other)
        {
            other.gameObject.GetComponent<IDamageReceiver>()?.TakeDamage(damagePoints);
        }
    }
}
