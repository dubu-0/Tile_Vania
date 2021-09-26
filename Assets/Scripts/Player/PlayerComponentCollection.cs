using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerRunComponent))]
    [RequireComponent(typeof(PlayerJumpComponent))]
    [RequireComponent(typeof(PlayerClimbComponent))]
    public sealed class PlayerComponentCollection : MonoBehaviour
    {
        private PlayerComponentCollection() { }
        
        public static SpriteRenderer SpriteRenderer { get; private set; }
        public static BoxCollider2D BodyCollider2D { get; private set; }
        public static CapsuleCollider2D FeetCollider2D { get; private set; }
        public static Rigidbody2D Rigidbody2D { get; private set; }
        public static Animator Animator { get; private set; } 
        public static Player Player { get; private set; }
        public static PlayerRunComponent RunComponent { get; private set; }
        public static PlayerJumpComponent JumpComponent { get; private set; }
        public static PlayerClimbComponent ClimbComponent { get; private set; }

        private void Awake()
        {
            Player = GetComponent<Player>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            BodyCollider2D = GetComponent<BoxCollider2D>();
            FeetCollider2D = GetComponent<CapsuleCollider2D>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
            RunComponent = GetComponent<PlayerRunComponent>();
            JumpComponent = GetComponent<PlayerJumpComponent>();
            ClimbComponent = GetComponent<PlayerClimbComponent>();
        }
    }
}
