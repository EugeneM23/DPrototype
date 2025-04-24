using Modules;
using UnityEngine;

namespace Gameplay
{
    public class EnemyStateObserver
    {
        public bool IsAttaking { private set; get; }
        public bool IsPatroling { private set; get; }
        public bool IsChasing { private set; get; }

        private readonly PlayerTransform _player;
        private readonly HealthComponent _enemy;
        private readonly float _chaseRange;
        private readonly float _attckRange;

        public EnemyStateObserver(PlayerTransform player, HealthComponent enemy, float chaseRange, float attckRange)
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
            IsPatroling = (state == AIState.Patrol);
            IsChasing = (state == AIState.Chase);
            IsAttaking = (state == AIState.Attack);
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