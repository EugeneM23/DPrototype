using Gameplay.Modules;
using UnityEngine;

namespace Gameplay
{
    public class EnemyStateManager
    {
        public bool IsAttacking { get; private set; }
        public bool IsPatroling { get; private set; }
        public bool IsChasing { get; private set; }

        public bool IsBusy;

        private readonly PlayerTransform _player;
        private readonly HealthComponentBase _enemy;
        private readonly float _chaseRange;
        private readonly float _attckRange;

        public EnemyStateManager(PlayerTransform player, HealthComponentBase enemy, float chaseRange, float attckRange)
        {
            _player = player;
            _enemy = enemy;
            _chaseRange = chaseRange;
            _attckRange = attckRange;
        }

        public bool GetPatrolCondition()
        {
            if (!PlayerInChaseRange() && !PlayerInAttackRange())
            {
                SetState(EnemyState.Patrol);
                return true;
            }

            return false;
        }

        public bool GetChaseCondition()
        {
            if (PlayerInChaseRange() && !PlayerInAttackRange())
            {
                SetState(EnemyState.Chase);
                return true;
            }

            return false;
        }

        public bool GetAttackCondition()
        {
            if (PlayerInAttackRange())
            {
                SetState(EnemyState.Attack);
                return true;
            }

            return false;
        }

        private void SetState(EnemyState state)
        {
            IsPatroling = state == EnemyState.Patrol;
            IsChasing = state == EnemyState.Chase;
            IsAttacking = state == EnemyState.Attack;
        }

        private bool PlayerInChaseRange() =>
            Vector3.Distance(_enemy.transform.position, _player.transform.position) <= _chaseRange;

        private bool PlayerInAttackRange() =>
            Vector3.Distance(_enemy.transform.position, _player.transform.position) <= _attckRange;
    }
}