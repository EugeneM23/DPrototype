using Modules;
using UnityEngine;

namespace Gameplay
{
    public class EnemyStateObserver
    {
        public bool IsAttacking { get; private set; }
        public bool IsPatroling { get; private set; }
        public bool IsChasing { get; private set; }

        public bool IsBusy;

        private readonly PlayerTransform _player;
        private readonly EnemyHealthComponent _enemy;
        private readonly float _chaseRange;
        private readonly float _attckRange;

        public EnemyStateObserver(PlayerTransform player, EnemyHealthComponent enemy, float chaseRange, float attckRange)
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
                SetState(AIState.Patrol);
                return true;
            }

            return false;
        }

        public bool GetChaseCondition()
        {
            if (PlayerInChaseRange() && !PlayerInAttackRange())
            {
                SetState(AIState.Chase);
                return true;
            }

            return false;
        }

        public bool GetAttackCondition()
        {
            if (PlayerInAttackRange())
            {
                SetState(AIState.Attack);
                return true;
            }

            return false;
        }
        
        private void SetState(AIState state)
        {
            IsPatroling = state == AIState.Patrol;
            IsChasing = state == AIState.Chase;
            IsAttacking = state == AIState.Attack;
        }

        private bool PlayerInChaseRange() =>
            Vector3.Distance(_enemy.transform.position, _player.Transform.position) <= _chaseRange;

        private bool PlayerInAttackRange() =>
            Vector3.Distance(_enemy.transform.position, _player.Transform.position) <= _attckRange;
    }

    public enum AIState
    {
        Patrol,
        Chase,
        Attack
    }
}