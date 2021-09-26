using System.Collections;
using Interfaces;
using Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class Player : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private int healthPoints = 1;

        private const float AfterDeathKickForce = 20f;

        public void TakeDamage(int value)
        {
            healthPoints -= value;
            (this as IDamageReceiver).TryDie();
        }

        bool IDamageReceiver.TryDie()
        {
            if (healthPoints > 0) return false;
            
            Die();
            PreventMovement();
            TakeKickAfterDeath();

            return true;
        }

        private void Die() => 
            PlayerComponentCollection.Animator.SetBool(AnimatorParameterCollection.IsDead, true);
        private void TakeKickAfterDeath() =>
            PlayerComponentCollection.Rigidbody2D.velocity += GetRandomDirection() * AfterDeathKickForce;
        private void PreventMovement()
        {
            PlayerComponentCollection.RunComponent.enabled = false;
            PlayerComponentCollection.ClimbComponent.enabled = false;
            PlayerComponentCollection.JumpComponent.enabled = false;
        }
        private Vector2 GetRandomDirection() => new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f));
    }
}