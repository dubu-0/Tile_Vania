using System;
using System.Collections;
using Collections;
using Game_Session;
using Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Player
{
    public class Player : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private int healthPoints = 1;
        [SerializeField] private GameSessionController gameSessionController;
        
        private const float AfterDeathKickForce = 20f;

        public void TakeDamage(int value)
        {
            healthPoints -= value;
            (this as IDamageReceiver).TryDie();
        }

        bool IDamageReceiver.TryDie()
        {
            if (healthPoints > 0) return false;
            
            DisableMovement();
            KillPlayer();
            
            return true;
        }

        public void KickPlayer() => 
            PlayerComponentCollection.Rigidbody2D.velocity += GetRandomDirection() * AfterDeathKickForce;

        public void EnableMovement()
        {
            PlayerComponentCollection.RunComponent.enabled = true;
            PlayerComponentCollection.ClimbComponent.enabled = true;
            PlayerComponentCollection.JumpComponent.enabled = true;
        }
    
        public void DisableMovement()
        {
            PlayerComponentCollection.RunComponent.enabled = false;
            PlayerComponentCollection.ClimbComponent.enabled = false;
            PlayerComponentCollection.JumpComponent.enabled = false;
        }

        private void KillPlayer()
        {
            PlayerComponentCollection.Animator.SetBool(AnimatorParameters.IsDead, true);
            PlayerComponentCollection.Player.enabled = false;
            gameSessionController.RestartCurrentScene(2f);
        }
        
        private Vector2 GetRandomDirection() => new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f));
    }
}