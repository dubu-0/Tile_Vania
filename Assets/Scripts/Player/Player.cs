using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private int healthPoints;
        
        private static readonly int IsDying = Animator.StringToHash(nameof(IsDying));
        
        private Animator _animator;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void TakeDamage(int value)
        {
            healthPoints -= value;
            TryDie();
        }

        public bool TryDie()
        {
            if (healthPoints <= 0) Die();
            return healthPoints <= 0;
        }

        private void Die()
        {
            _animator.SetBool(IsDying, true);
            gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}