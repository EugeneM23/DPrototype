using System;
using Gameplay.BehComponents;
using Modules.PrefabPool;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class Enemy : ITickable, IDespawned
    {
        public event Action<GameObject> DeSpawn;

        private readonly Transform _enemyTransform;
        private readonly EnemyBehaviour _behaviour;
        private readonly EnemyConditions _conditions;
        private readonly NavMeshAgent _agent;

        private readonly float _chaseRange;
        private readonly float _attckrange;
        public float ChaseRange => _chaseRange;
        public float AttckRange => _attckrange;

        public Enemy(Transform enemyTransform, EnemyBehaviour behaviour, float chaseRange, float attckrange,
            EnemyConditions conditions)
        {
            _agent = enemyTransform.GetComponent<NavMeshAgent>();
            _enemyTransform = enemyTransform;
            _behaviour = behaviour;
            _conditions = conditions;

            _chaseRange = chaseRange;
            _attckrange = attckrange;

            enemyTransform.GetComponent<AttackAnimationProvider>().SetCondition(_conditions);
        }

        public void Tick()
        {
            if (_conditions.GetPatrolCondition())
                _behaviour.Patrol();

            if (_conditions.GetChaseCondition())
                _behaviour.Chase();

            if (_conditions.GetAttackCondition())
                _behaviour.Attack();
            
            Debug.Log(_enemyTransform.position);
        }



        public void Destroy(GameObject obj) => DeSpawn?.Invoke(_enemyTransform.gameObject);

        public NavMeshAgent GetAgent()
        {
            return _agent;
        }
    }
}