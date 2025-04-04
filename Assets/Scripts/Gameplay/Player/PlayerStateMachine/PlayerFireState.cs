using UnityEngine;

namespace Gameplay
{
    public class PlayerFireState : IPlayerState
    {
        private readonly PlayerStateMachine _stateMachine;
        private readonly Player _player;
        private Enemy[] _enemies;
        private int _aimDistance;

        public PlayerFireState(PlayerStateMachine stateMachine, Player player, Enemy[] enemies,
            PlayerParameters parameters)
        {
            _stateMachine = stateMachine;
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
            if (_player.GetVelocity() != Vector3.zero)
                _stateMachine.SetState<PlayerMoveState>();

            if (_enemies.Length <= 0)
                return;

            (float distance, Enemy target) = CalculateDistance();

            if (distance < _aimDistance)
            {
                _player.LookAt(target.transform.position);

                if (HasLookedAt(target.transform.position))
                    _player.Shoot(target.transform);
            }
            else
            {
                _stateMachine.SetState<PlayerIdleState>();
            }
        }

        public bool HasLookedAt(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - _player.transform.position;
            direction.y = 0f;

            if (direction == Vector3.zero)
                return true;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            float angle = Quaternion.Angle(_player.transform.rotation, targetRotation);

            return angle < 1f;
        }

        private (float minDistance, Enemy closest) CalculateDistance()
        {
            Enemy closest = null;
            float minDistance = Mathf.Infinity;

            foreach (Enemy t in _enemies)
            {
                float distance = Vector3.Distance(_player.transform.position, t.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = t;
                }
            }

            return (minDistance, closest);
        }
    }
}