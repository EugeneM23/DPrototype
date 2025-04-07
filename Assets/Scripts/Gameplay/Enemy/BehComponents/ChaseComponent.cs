using System;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.BehComponents
{
    public class ChaseComponent : MonoBehaviour
    {
        [SerializeField] private EnemyConditions _conditions;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Enemy _enemy;

        private void Update()
        {
            if (_conditions.IsOnAnimation) return;

            if (_enemy.PlayerInAttackRange() || !_enemy.PlayerInChaseRange())
            {
                _conditions.IsChasing = false;
                return;
            }

            if (!_enemy.PlayerInAttackRange() && !_enemy.PlayerInChaseRange())
            {
                _conditions.IsChasing = false;
                _agent.SetDestination(_enemy.transform.position);
                return;
            }

            if (_enemy.PlayerInChaseRange())
            {
                _conditions.IsChasing = true;
                _agent.SetDestination(_enemy.Target.transform.position);
                _agent.speed = 8;
            }
        }
    }
}