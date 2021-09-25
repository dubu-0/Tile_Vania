using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Settings;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerRunBehaviour))]
    [RequireComponent(typeof(PlayerJumpBehaviour))]
    [RequireComponent(typeof(PlayerClimbBehaviour))]
    public class Player : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private int healthPoints = 1;
        [SerializeField] private float afterDeathKickForce = 20f;
        
        private Animator _animator;
        private Rigidbody2D _myRigidbody2D;
        private PlayerRunBehaviour _playerRunBehaviour;
        private PlayerJumpBehaviour _playerJumpBehaviour;
        private PlayerClimbBehaviour _playerClimbBehaviour;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _myRigidbody2D = GetComponent<Rigidbody2D>();
            _playerRunBehaviour = GetComponent<PlayerRunBehaviour>();
            _playerJumpBehaviour = GetComponent<PlayerJumpBehaviour>();
            _playerClimbBehaviour = GetComponent<PlayerClimbBehaviour>();
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
            _animator.SetBool(AnimatorParameters.IsDead, true);
            PreventMovement();
            TakeAfterDeathKick();
        }

        private void TakeAfterDeathKick() =>
            _myRigidbody2D.velocity += GetRandomDirection() * afterDeathKickForce;

        private void PreventMovement()
        {
            _playerRunBehaviour.enabled = false;
            _playerClimbBehaviour.enabled = false;
            _playerJumpBehaviour.enabled = false;
        }

        private Vector2 GetRandomDirection() => new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f));
    }
}