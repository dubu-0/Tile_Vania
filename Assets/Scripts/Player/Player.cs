using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEditor.Animations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class Player : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private int healthPoints;
        [SerializeField] private float pushAfterDeathForce;
        
        private static readonly int IsDying = Animator.StringToHash(nameof(IsDying));
        
        private Animator _animator;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void TakeDamage(int value)
        {
            healthPoints -= value;
            (this as IDamageReceiver).TryDie();
        }

        bool IDamageReceiver.TryDie()
        {
            if (healthPoints <= 0) Die();
            return healthPoints <= 0;
        }

        private void Die()
        {
            _animator.SetBool(IsDying, true);
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().velocity += GetRandomPushDirection() * pushAfterDeathForce;
        }

        private Vector2 GetRandomPushDirection()
        {
            return new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f));
        }
    }
}