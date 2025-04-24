using System;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class AttackComponent
    {
        private readonly NavMeshAgent _agent;
        private readonly RotationToTarget _rotator;
        private readonly PlayerTransform _target;
        private readonly Transform _enemy;

        public AttackComponent(RotationToTarget rotator, PlayerTransform player,
            NavMeshAgent agent, Transform enemy)
        {
            _rotator = rotator;
            _agent = agent;
            _enemy = enemy;
            _target = player;
        }

        public void Attack()
        {
            _agent.isStopped = true;
            _rotator.Rotation(_enemy, _target);
        }
    }
}