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
        private PatrolComponent _patrolComponent;
        private AttackComponent _attackComponent;
        private ChaseComponent _chaseComponent;
        //public PlayerTransform GetTarget => _attackComponent.Target;

        private void OnEnable() => _healthComponent.OnDeath += Despawn;

        private void OnDisable() => _healthComponent.OnDeath -= Despawn;

        [Inject]
        public void Construct(EnemyConditions conditions, PatrolComponent patrolState,
            AttackComponent attackState, ChaseComponent chaseState, HealthComponent healthComponent)
        {
            _conditions = conditions;
            _healthComponent = healthComponent;
            _patrolComponent = patrolState;
            _attackComponent = attackState;
            _chaseComponent = chaseState;
        }

        private void Update()
        {
            if (_conditions.GetPatrolCondition())
                _patrolComponent.Patrol();

            if (_conditions.GetChaseCondition())
                _chaseComponent.Chase();

            if (_conditions.GetAttackCondition())
                _attackComponent.Attack();
        }

        private void Despawn() => DeSpawn?.Invoke(this);

        public void SetPosition(Vector3 position) => transform.position = position;

        public void Kill() => Despawn();
    }
}