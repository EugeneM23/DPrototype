using UnityEngine;

namespace Gameplay.BehComponents
{
    /*public class EnemyConditions
    {
        public bool IsChasing;
        public bool IsPatroling;
        public bool IsAidling;
        public bool IsAttaking;
        public bool IsOnAnimation;

        private readonly PlayerTransform _player;
        private readonly HealthComponent _enemy;
        private readonly float _chaseRange;
        private readonly float _attckRange;

        public EnemyConditions(PlayerTransform player, HealthComponent enemy, float chaseRange, float attckRange)
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
            Vector3.Distance(_enemy.transform.position, _player.Transform.position) <= _chaseRange;

        private bool PlayerInAttackRange() =>
            Vector3.Distance(_enemy.transform.position, _player.Transform.position) <= _attckRange;
    }*/
}