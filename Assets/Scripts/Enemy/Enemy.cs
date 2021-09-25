using System;
using Interfaces;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int damagePoints = 1;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.gameObject.GetComponent<IDamageReceiver>()?.TakeDamage(damagePoints);
        }
    }
}
