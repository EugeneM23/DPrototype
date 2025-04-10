using System;
using Gameplay.BehComponents;
using Modules.PrefabPool;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class Enemy : MonoBehaviour
    {
        public event Action<Enemy> DeSpawn;

        private EnemyConditions _conditions;
        private NavMeshAgent _agent;

        private PatrolComponent _patrolState;
        private AttackComponent _attackState;
        private ChaseComponent _chaseState;

        [Inject]
        public void Construct(EnemyConditions conditions, NavMeshAgent agent, PatrolComponent patrolState,
            AttackComponent attackState, ChaseComponent chaseState)
        {
            _conditions = conditions;
            _agent = agent;

            _patrolState = patrolState;
            _attackState = attackState;
            _chaseState = chaseState;
        }

        private void Update()
        {
            if (_conditions.GetPatrolCondition())
                _patrolState.Patrol();

            if (_conditions.GetChaseCondition())
                _chaseState.Chase();

            if (_conditions.GetAttackCondition())
                _attackState.Attack();
        }

        public void Destroy(GameObject obj)
        {
            DeSpawn?.Invoke(this);
        }
    }
}