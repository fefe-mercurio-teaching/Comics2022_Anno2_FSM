using UnityEngine;

namespace FSM
{
    public class PlayerStateWalk : State
    {
        private StateMachine<PlayerStates> _stateMachine;
        private Rigidbody2D _rigidbody;
        private float _speed;

        public PlayerStateWalk(StateMachine<PlayerStates> stateMachine, Rigidbody2D rigidbody, 
            float speed)
        {
            _stateMachine = stateMachine;
            _rigidbody = rigidbody;
            _speed = speed;
        }
        
        public override void OnBegin()
        {
            Debug.Log("Sono nello stato Walk");
        }

        public override void OnUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");

            if (horizontal == 0f)
            {
                _stateMachine.SetState(PlayerStates.Idle);
                return;
            }

            horizontal *= _speed * Time.deltaTime;

            _rigidbody.position += Vector2.right * horizontal;
        }
    }
}