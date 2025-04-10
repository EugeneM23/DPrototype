using System;
using Gameplay.BehComponents;
using Gameplay.Common;
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

        private HealthComponent _healthComponent;
        private PatrolComponent _patrolState;
        private AttackComponent _attackState;
        private ChaseComponent _chaseState;

     

        private void OnEnable() => _healthComponent.OnDeath += Destroy;

        private void OnDisable() => _healthComponent.OnDeath -= Destroy;

        [Inject]
        public void Construct(EnemyConditions conditions, PatrolComponent patrolState,
            AttackComponent attackState, ChaseComponent chaseState, HealthComponent healthComponent)
        {
            _conditions = conditions;
            _healthComponent = healthComponent;
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

        private void Destroy()
        {
            Debug.Log("asdasd");
            DeSpawn?.Invoke(this);
        }

        public void SetPosition(Vector3 p1)
        {
            transform.position = p1;
        }
    }
}