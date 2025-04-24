using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Enemy : ITickable
    {
        private readonly EnemyStateManager _stateManager;

        private readonly EnemyPatrolComponent _enemyPatrolComponent;
        private readonly EnemyAttackComponent _enemyAttackComponent;
        private readonly EnemyChaseComponent _enemyChaseComponent;

        public Enemy(EnemyStateManager stateManager,
            EnemyPatrolComponent enemyPatrolComponent,
            EnemyChaseComponent enemyChaseComponent,
            EnemyAttackComponent enemyAttackComponent)
        {
            _stateManager = stateManager;
            _enemyPatrolComponent = enemyPatrolComponent;
            _enemyChaseComponent = enemyChaseComponent;
            _enemyAttackComponent = enemyAttackComponent;
        }

        public void Tick()
        {
            if (_stateManager.IsBusy) return;

            if (_stateManager.GetPatrolCondition())
                _enemyPatrolComponent.Patrol();

            if (_stateManager.GetChaseCondition())
                _enemyChaseComponent.Chase();

            if (_stateManager.GetAttackCondition())
                _enemyAttackComponent.Attack();
        }
    }
}