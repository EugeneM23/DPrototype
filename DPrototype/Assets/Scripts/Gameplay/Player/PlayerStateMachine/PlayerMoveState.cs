using UnityEngine;

namespace Gameplay.Player
{
    internal class PlayerMoveState : IPlayerState
    {
        private readonly PlayerStateMachine _stateMachine;
        private readonly Player _player;
        private readonly PlayerInput _playerInput;

        public PlayerMoveState(PlayerStateMachine stateMachine, PlayerInput playerInput, Player player)
        {
            _player = player;
            _playerInput = playerInput;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            Debug.Log("Enter move");
        }

        public void Exit()
        {
            Debug.Log("Exit run");
        }

        public void Update()
        {
            if (_playerInput.Axis == Vector3.zero)
                _stateMachine.SetState<PlayerIdleState>();

            _player.Move(_playerInput.Axis);
            Debug.Log("Update run");
        }
    }
}