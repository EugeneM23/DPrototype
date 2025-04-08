using Gameplay.BehComponents;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class ChaseComponent
    {
        private readonly NavMeshAgent _agent;
        private readonly EnemyConditions _conditions;
        private readonly GameObject _target;

        public ChaseComponent(NavMeshAgent agent, EnemyConditions conditions, GameObject target)
        {
            _agent = agent;
            _conditions = conditions;
            _target = target;
        }

        public void Chase()
        {
            _agent.isStopped = false;
            _conditions.IsPatroling = false;
            _conditions.IsChasing = true;

            _agent.SetDestination(_target.transform.position);
            _agent.speed = 8;
        }
    }
}