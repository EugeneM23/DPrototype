using Gameplay.BehComponents;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class AttackComponent
    {
        private readonly EnemyConditions _conditions;
        private readonly NavMeshAgent _agent;
        private readonly RotationToTarget _rotator;

        public AttackComponent(EnemyConditions conditions, NavMeshAgent agent, RotationToTarget rotator)
        {
            _conditions = conditions;
            _agent = agent;
            _rotator = rotator;
        }

        public void Attack()
        {
            _conditions.IsPatroling = false;
            _conditions.IsChasing = false;
            _conditions.IsAttaking = true;
            _agent.isStopped = true;

            _rotator.Rotation(_agent.transform, _agent.GetComponent<Enemy>().Target);
        }
    }
}