using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerIdleState : IPlayerState
    {
        private readonly PlayerStateMachine _stateMachine;
        private readonly PlayerInput _playerInput;
        private readonly Player _player;
        private Enemy[] _enemies;
        private float _sootRangeDistance = 6;

        public PlayerIdleState(PlayerStateMachine stateMachine, PlayerInput playerInput, Player player, Enemy[] enemies)
        {
            _stateMachine = stateMachine;
            _playerInput = playerInput;
            _player = player;
            _enemies = enemies;
        }

        public void Enter()
        {
            Debug.Log("Idle State");
        }

        public void Exit()
        {
            Debug.Log("Exit Idle");
        }

        public void Update()
        {
            if (_playerInput.Axis != Vector3.zero)
                _stateMachine.SetState<PlayerMoveState>();

            if (CalculateDistance() < _sootRangeDistance)
                _stateMachine.SetState<PlayerFireState>();

            _player.Move(Vector3.zero);
            Debug.Log("Update idle");
        }

        private float CalculateDistance()
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

            return minDistance;
        }
    }
}