using UnityEngine;

namespace Gameplay.BehComponents
{
    public class EnemyConditions
    {
        public bool IsChasing;
        public bool IsPatroling;
        public bool IsAidling;
        public bool IsAttaking;
        public bool IsOnAnimation;

        private readonly Player _player;
        private readonly Transform _enemyTransform;
        private readonly float _chaseRange;
        private readonly float _attckRange;

        public EnemyConditions(Player player, Transform enemyTransform, float chaseRange, float attckRange)
        {
            _player = player;
            _enemyTransform = enemyTransform;
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
            Vector3.Distance(_enemyTransform.transform.position, _player.GetTransform().position) <= _chaseRange;

        private bool PlayerInAttackRange() =>
            Vector3.Distance(_enemyTransform.position, _player.GetTransform().position) <= _attckRange;
    }
}