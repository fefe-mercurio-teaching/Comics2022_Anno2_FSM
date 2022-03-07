using UnityEngine;

namespace FSM
{
    public class PlayerStateJump : State
    {
        private Rigidbody2D _rigidbody;
        private StateMachine<PlayerStates> _stateMachine;
        private PlayerController _playerController;

        public PlayerStateJump(StateMachine<PlayerStates> stateMachine, Rigidbody2D rigidbody, PlayerController playerController)
        {
            _stateMachine = stateMachine;
            _rigidbody = rigidbody;
            _playerController = playerController;
        }

        public override void OnBegin()
        {
            _rigidbody.AddForce(Vector2.up * _playerController.JumpIntensity);
        }

        public override void OnUpdate()
        {
            if (_rigidbody.velocity.y < 0f)
            {
                _stateMachine.SetState(PlayerStates.Fall);
                return;
            }
            
            float horizontal = Input.GetAxis("Horizontal");

            if (horizontal == 0f)
            {
                _stateMachine.SetState(PlayerStates.Idle);
                return;
            }

            horizontal *= _playerController.Speed * Time.deltaTime;

            _rigidbody.position += Vector2.right * horizontal;
        }
    }
}