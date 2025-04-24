using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class EnemyAttackComponent
    {
        private readonly NavMeshAgent _agent;
        private readonly EnemyStateManager _stateManager;
        private readonly Animator _animator;

        public EnemyAttackComponent(NavMeshAgent agent, EnemyStateManager stateManager, Animator animator)
        {
            _agent = agent;
            _stateManager = stateManager;
            _animator = animator;
        }

        public void Attack()
        {
            if (_stateManager.IsAttacking && !_stateManager.IsBusy)
            {
                _animator.Play("Attack_01");
                _stateManager.IsBusy = true;
                _agent.isStopped = true;
            }
        }
    }
}