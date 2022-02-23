using UnityEngine;

namespace FSM
{
    public class PlayerStateAttack : State
    {
        private StateMachine<PlayerStates> _stateMachine;
        private SpriteRenderer _spriteRenderer;
        private float _timeElapsed;
        private Color _originalColor;

        public PlayerStateAttack(StateMachine<PlayerStates> stateMachine, SpriteRenderer spriteRenderer)
        {
            _stateMachine = stateMachine;
            _spriteRenderer = spriteRenderer;
        }

        public override void OnBegin()
        {
            _timeElapsed = 0f;
            _originalColor = _spriteRenderer.color;
            _spriteRenderer.color = Color.green;
        }

        public override void OnEnd()
        {
            _spriteRenderer.color = _originalColor;
        }

        public override void OnUpdate()
        {
            _timeElapsed += Time.deltaTime;

            if (_timeElapsed >= 1.5f)
            {
                _stateMachine.SetState(PlayerStates.Idle);
            }
        }
    }
}