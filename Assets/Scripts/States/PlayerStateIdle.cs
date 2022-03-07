using UnityEngine;

namespace FSM
{
    public class PlayerStateIdle : State
    {
        private StateMachine<PlayerStates> _stateMachine;
        private PlayerController _playerController;

        public PlayerStateIdle(StateMachine<PlayerStates> stateMachine, PlayerController playerController)
        {
            _stateMachine = stateMachine;
            _playerController = playerController;
        }
        
        public override void OnBegin()
        {
            Debug.Log("Sono nello stato Idle");
        }

        public override void OnFixedUpdate()
        {
            if (_playerController.IsFalling)
            {
                _stateMachine.SetState(PlayerStates.Fall);
            }
        }

        public override void OnUpdate()
        {
            if (Input.GetButtonDown("Jump"))
            {
                _stateMachine.SetState(PlayerStates.Jump);
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