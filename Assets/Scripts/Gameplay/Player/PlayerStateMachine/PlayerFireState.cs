using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerFireState : IPlayerState
    {
        private readonly PlayerStateMachine _stateMachine;
        private readonly PlayerInput _playerInput;
        private readonly Player _player;
        private Enemy[] _enemies;
        private int _aimDistance;

        public PlayerFireState(PlayerStateMachine stateMachine, PlayerInput playerInput, Player player, Enemy[] enemies,
            PlayerParameters parameters)
        {
            _stateMachine = stateMachine;
            _playerInput = playerInput;
            _player = player;
            _enemies = enemies;
            _aimDistance = parameters.AimingDistance;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Update()
        {
            if (_playerInput.Axis != Vector3.zero)
                _stateMachine.SetState<PlayerMoveState>();

            (float distance, Enemy target) = CalculateDistance();

            if (distance < _aimDistance)
            {
                _player.LookAt(target.transform.position);
                _player.Shoot(target.transform);
            }
            else
            {
                _stateMachine.SetState<PlayerIdleState>();
            }
        }

        private (float minDistance, Enemy closest) CalculateDistance()
        {
            Enemy closest = null;
            float minDistance = Mathf.Infinity;

            foreach (var item in _enemies)
            {
                foreach (Enemy t in _enemies)
                {
                    float distance = Vector3.Distance(_player.transform.position, t.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closest = t;
                    }
                }
            }

            return (minDistance, closest);
        }
    }
}