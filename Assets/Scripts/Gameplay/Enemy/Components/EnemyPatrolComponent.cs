using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class EnemyPatrolComponent
    {
        private readonly NavMeshAgent _agent;
        private readonly EnemyPatrolPointManager _patrolPointManager;
        private readonly float _patrolSpeed;

        public EnemyPatrolComponent(EnemyPatrolPointManager patrolPointManager,
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