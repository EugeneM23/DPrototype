using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class EnemyChaseComponent
    {
        private readonly NavMeshAgent _agent;
        private readonly Transform _target;
        private readonly float _speed;

        public EnemyChaseComponent(Transform target, NavMeshAgent enemy, float speed)
        {
            _agent = enemy;
            _speed = speed;
            _target = target;
        }

        public void Chase()
        {
            _agent.isStopped = false;

            _agent.SetDestination(_target.position);
            _agent.speed = _speed;
        }
    }
}