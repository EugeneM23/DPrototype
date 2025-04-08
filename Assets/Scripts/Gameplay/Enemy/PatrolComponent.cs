using Gameplay.BehComponents;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class PatrolComponent
    {
        private readonly NavMeshAgent _agent;
        private readonly EnemyConditions _conditions;
        private readonly EnemyPatrolPointManager _patrolPointManager;

        public PatrolComponent(NavMeshAgent agent, EnemyConditions conditions,
            EnemyPatrolPointManager patrolPointManager)
        {
            _agent = agent;
            _conditions = conditions;
            _patrolPointManager = patrolPointManager;
        }

        public void Patrol()
        {
            _agent.isStopped = false;

            _conditions.IsPatroling = true;
            _conditions.IsChasing = false;
            _conditions.IsAttaking = false;

            _agent.speed = 2.5f;

            if (_agent.remainingDistance <= 1)
            {
                Vector3 destination = _patrolPointManager.GetNext();
                _agent.SetDestination(destination);
            }
        }
    }
}