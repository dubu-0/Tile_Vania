using System;
using Interfaces;
using Player;
using UnityEngine;

namespace Hazards
{
    public class Water : MonoBehaviour
    {
        [SerializeField] private int damagePoints = 999999;

        private void OnTriggerEnter2D(Collider2D other)
        {
            other.gameObject.GetComponent<IDamageReceiver>()?.TakeDamage(damagePoints);
        }
    }
}
