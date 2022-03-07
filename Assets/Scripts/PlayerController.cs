using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpIntensity;
        [SerializeField] private float fallingOffset = -0.1f;

        private Rigidbody2D _rigidbody;

        public float JumpIntensity => jumpIntensity;
        public float Speed => speed;

        public bool IsFalling => _rigidbody.velocity.y < fallingOffset;

        private StateMachine<PlayerStates> _stateMachine = new StateMachine<PlayerStates>();

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            
            _stateMachine.RegisterState(PlayerStates.Idle, new PlayerStateIdle(_stateMachine, this));
            _stateMachine.RegisterState(PlayerStates.Walk, new PlayerStateWalk(_stateMachine, _rigidbody, speed));
            _stateMachine.RegisterState(PlayerStates.Attack, new PlayerStateAttack(_stateMachine, spriteRenderer));
            _stateMachine.RegisterState(PlayerStates.Fall, new PlayerStateFall(_stateMachine, _rigidbody, spriteRenderer));
            _stateMachine.RegisterState(PlayerStates.Jump, new PlayerStateJump(_stateMachine, _rigidbody, this));
            
            _stateMachine.SetState(PlayerStates.Idle);
        }

        private void FixedUpdate() => _stateMachine.OnFixedUpdate();

        private void Update()
        {
            _stateMachine.OnUpdate();
        }
        
        
    }
}