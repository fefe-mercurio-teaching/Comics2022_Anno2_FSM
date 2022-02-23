using UnityEngine;

namespace FSM
{
    public class PlayerStateIdle : State
    {
        private StateMachine<PlayerStates> _stateMachine;
        private Rigidbody2D _rigidbody;

        public PlayerStateIdle(StateMachine<PlayerStates> stateMachine, Rigidbody2D rigidbody)
        {
            _stateMachine = stateMachine;
            _rigidbody = rigidbody;
        }
        
        public override void OnBegin()
        {
            Debug.Log("Sono nello stato Idle");
        }

        public override void OnUpdate()
        {
            if (_rigidbody.velocity.y < 0f)
            {
                _stateMachine.SetState(PlayerStates.Fall);
                return;
            }
            
            if (Input.GetAxis("Horizontal") != 0f)
            {
                _stateMachine.SetState(PlayerStates.Walk);
                return;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _stateMachine.SetState(PlayerStates.Attack);
            }
        }
    }
}