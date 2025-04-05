using UnityEngine;

namespace Gameplay
{
    public class PlayerFireState : IPlayerState
    {
        private readonly PlayerStateMachine _stateMachine;
        private readonly Player _player;
        private readonly EnemyManager _enemyManager;

        public PlayerFireState(PlayerStateMachine stateMachine, Player player, EnemyManager enemyManager)
        {
            _stateMachine = stateMachine;
            _player = player;
            _enemyManager = enemyManager;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Update()
        {
            /*if (_player.GetVelocity() != Vector3.zero)
                _stateMachine.SetState<PlayerMoveState>();


            if (_enemyManager.TryGetTarget(_player.GetWeaponFirerange(), out GameObject target))
            {
                _player.LookAt(target.transform.position);

                if (HasLookedAt(target.transform.position))
                    _player.Shoot(target.transform);
            }
            else
            {
                _stateMachine.SetState<PlayerIdleState>();
            }*/
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
    }
}