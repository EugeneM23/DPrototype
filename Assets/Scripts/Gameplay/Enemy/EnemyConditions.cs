using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.BehComponents
{
    public class EnemyConditions
    {
        public bool IsChasing;
        public bool IsPatroling;
        public bool IsAidling;
        public bool IsAttaking;
        public bool IsOnAnimation;

        private readonly Transform _player;
        private readonly Transform _enemy;
        private readonly float _chaseRange;
        private readonly float _attckRange;

        public EnemyConditions(Transform player, Transform enemy, float chaseRange, float attckRange)
        {
            _player = player;
            _enemy = enemy;
            _chaseRange = chaseRange;
            _attckRange = attckRange;
        }

        public bool GetPatrolCondition()
        {
            if (!PlayerInChaseRange() && !PlayerInAttackRange() && !IsAttaking)
                return true;

            return false;
        }

        public bool GetChaseCondition()
        {
            if (PlayerInChaseRange() && !PlayerInAttackRange() && !IsAttaking)
                return true;

            return false;
        }

        public bool GetAttackCondition()
        {
            if (PlayerInAttackRange())
                return true;

            return false;
        }

        private bool PlayerInChaseRange() =>
            Vector3.Distance(_enemy.transform.position, _player.position) <= _chaseRange;

        private bool PlayerInAttackRange() =>
            Vector3.Distance(_enemy.position, _player.position) <= _attckRange;
    }
}