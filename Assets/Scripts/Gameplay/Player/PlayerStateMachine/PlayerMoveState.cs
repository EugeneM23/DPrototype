using UnityEngine;

namespace Gameplay
{
    internal class PlayerMoveState : IPlayerState
    {
        private readonly PlayerStateMachine _stateMachine;
        private readonly Player _player;

        public PlayerMoveState(PlayerStateMachine stateMachine, Player player)
        {
            _player = player;
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
            if (_player.GetVelocity() == Vector3.zero)
                _stateMachine.SetState<PlayerIdleState>();
        }
    }
}