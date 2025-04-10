using Gameplay.BehComponents;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class ChaseComponent
    {
        private readonly NavMeshAgent _agent;
        private readonly EnemyConditions _conditions;
        private readonly Transform _target;

        public ChaseComponent(EnemyConditions conditions, Player target, NavMeshAgent enemy)
        {
            _conditions = conditions;
            _agent = enemy;
            _target = target.GetTransform();
        }

        public void Chase()
        {
            _agent.isStopped = false;
            _conditions.IsPatroling = false;
            _conditions.IsChasing = true;

            _agent.SetDestination(_target.position);
            _agent.speed = 5;
        }
    }
}