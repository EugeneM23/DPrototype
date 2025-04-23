using Gameplay.BehComponents;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    /*public class Enemy : ITickable
    {
        private EnemyConditions _conditions;

        private PatrolComponent _patrolComponent;
        private AttackComponent _attackComponent;
        private ChaseComponent _chaseComponent;

        public Enemy(EnemyConditions conditions, PatrolComponent patrolComponent, AttackComponent attackComponent,
            ChaseComponent chaseComponent)
        {
            _conditions = conditions;
            _patrolComponent = patrolComponent;
            _attackComponent = attackComponent;
            _chaseComponent = chaseComponent;
        }

        public void Tick()
        {
            if (_conditions.GetPatrolCondition())
                _patrolComponent.Patrol();

            if (_conditions.GetChaseCondition())
                _chaseComponent.Chase();

            if (_conditions.GetAttackCondition())
                _attackComponent.Attack();
        }
    }*/
}