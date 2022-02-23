using UnityEngine;

namespace FSM
{
    public class PlayerStateFall : State
    {
        private StateMachine<PlayerStates> _stateMachine;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;
        private Color _originalColor;

        public PlayerStateFall(StateMachine<PlayerStates> stateMachine, Rigidbody2D rigidbody,
            SpriteRenderer spriteRenderer)
        {
            _stateMachine = stateMachine;
            _rigidbody = rigidbody;
            _spriteRenderer = spriteRenderer;
        }

        public override void OnBegin()
        {
            _originalColor = _spriteRenderer.color;
            _spriteRenderer.color = Color.blue;
        }

        public override void OnEnd()
        {
            _spriteRenderer.color = _originalColor;
        }

        public override void OnUpdate()
        {
            if (_rigidbody.velocity.y >= 0f)
            {
                _stateMachine.SetState(PlayerStates.Idle);
            }
        }
    }
}