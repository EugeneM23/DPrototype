using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class PatrolComponent
    {
        private readonly NavMeshAgent _agent;
        private readonly EnemyPatrolPointManager _patrolPointManager;
        private float _patrolSpeed;

        public PatrolComponent(EnemyPatrolPointManager patrolPointManager,
            NavMeshAgent enemy, float patrolSpeed)
        {
            _agent = enemy;
            _patrolSpeed = patrolSpeed;
            _agent.enabled = true;
            _patrolPointManager = patrolPointManager;
        }

        public void Patrol()
        {
            _agent.isStopped = false;

            _agent.speed = _patrolSpeed;

            if (_agent.remainingDistance <= 1)
            {
                Vector3 destination = _patrolPointManager.GetNext();
                _agent.SetDestination(destination);
            }
        }
    }
}