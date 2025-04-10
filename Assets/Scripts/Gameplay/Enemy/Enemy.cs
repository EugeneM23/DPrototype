using System;
using Gameplay.BehComponents;
using UnityEngine;
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

        private void OnEnable() => _healthComponent.OnDeath += Despawn;

        private void OnDisable() => _healthComponent.OnDeath -= Despawn;

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

        private void Despawn() => DeSpawn?.Invoke(this);

        public void SetPosition(Vector3 position) => transform.position = position;
    }
}