using System;
using Gameplay.BehComponents;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class PatrolComponent : MonoBehaviour
    {
        [SerializeField] private EnemyConditions _conditions;
        [SerializeField] private EnemyPatrolPointManager _patrolPointManager;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Enemy _enemy;

        private void Start()
        {
            Vector3 destination = _patrolPointManager.GetNext();
            _agent.SetDestination(destination);
        }


        private void Update()
        {
            Debug.Log("Patrol");
            if (_conditions.IsOnAnimation) return;

            if (_enemy.PlayerInAttackRange() || _enemy.PlayerInChaseRange())
            {
                _conditions.IsPatroling = false;
                return;
            }

            _conditions.IsPatroling = true;
            _agent.speed = 2.5f;

            if (_agent.remainingDistance <= 1)
            {
                Vector3 destination = _patrolPointManager.GetNext();
                _agent.SetDestination(destination);
            }
        }
    }
}