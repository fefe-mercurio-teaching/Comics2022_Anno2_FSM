using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        private StateMachine<PlayerStates> _stateMachine = new StateMachine<PlayerStates>();

        private void Start()
        {
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            
            _stateMachine.RegisterState(PlayerStates.Idle, new PlayerStateIdle(_stateMachine, rigidbody2D));
            _stateMachine.RegisterState(PlayerStates.Walk, new PlayerStateWalk(_stateMachine, rigidbody2D, speed));
            _stateMachine.RegisterState(PlayerStates.Attack, new PlayerStateAttack(_stateMachine, spriteRenderer));
            _stateMachine.RegisterState(PlayerStates.Fall, new PlayerStateFall(_stateMachine, rigidbody2D, spriteRenderer));
            
            _stateMachine.SetState(PlayerStates.Idle);
        }

        private void Update()
        {
            _stateMachine.OnUpdate();
        }
    }
}