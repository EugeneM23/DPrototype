using System;
using Gameplay.BehComponents;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    /*public class AttackComponent
    {
        public event Action OnAttacked;

        private readonly EnemyConditions _conditions;
        private readonly NavMeshAgent _agent;
        private readonly RotationToTarget _rotator;
        private readonly PlayerTransform _target;
        private readonly EnemyTransform _enemy;

        public AttackComponent(EnemyConditions conditions, RotationToTarget rotator, PlayerTransform player,
            NavMeshAgent agent, EnemyTransform enemy)
        {
            _conditions = conditions;
            _rotator = rotator;
            _agent = agent;
            _enemy = enemy;
            _target = player;
        }

        public void Attack()
        {
            _conditions.IsPatroling = false;
            _conditions.IsChasing = false;
            _agent.isStopped = true;

            OnAttacked?.Invoke();

            _rotator.Rotation(_enemy.Transform, _target);
        }
    }*/
}