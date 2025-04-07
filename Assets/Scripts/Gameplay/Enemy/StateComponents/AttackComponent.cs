using System;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.BehComponents
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private EnemyConditions _conditions;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Enemy _enemy;


        private void Update()
        {
            if (_enemy.PlayerInAttackRange())
            {
                RotationToTarget();
                _conditions.IsAttaking = true;
                _conditions.IsPatroling = false;
                _conditions.IsChasing = false;
                _agent.isStopped = true;
            }
            else
            {
                _conditions.IsAttaking = false;
                _agent.isStopped = false;
            }
        }

        private void RotationToTarget()
        {
            Vector3 direction = _enemy.Target.transform.position - _enemy.transform.position;
            direction.y = 0;

            if (direction == Vector3.zero) return;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            _enemy.transform.rotation =
                Quaternion.Slerp(_enemy.transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}