using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Enemy : ITickable
    {
        private readonly EnemyStateObserver _stateObserver;

        private readonly PatrolComponent _patrolComponent;
        private readonly AttackComponent _attackComponent;
        private readonly ChaseComponent _chaseComponent;

        public Enemy(EnemyStateObserver stateObserver, PatrolComponent patrolComponent, ChaseComponent chaseComponent,
            AttackComponent attackComponent)
        {
            _stateObserver = stateObserver;
            _patrolComponent = patrolComponent;
            _chaseComponent = chaseComponent;
            _attackComponent = attackComponent;
        }

        public void Tick()
        {
            if (_stateObserver.GetPatrolCondition())
                _patrolComponent.Patrol();

            if (_stateObserver.GetChaseCondition())
                _chaseComponent.Chase();

            if (_stateObserver.GetAttackCondition())
                _attackComponent.Attack();
        }
    }
}