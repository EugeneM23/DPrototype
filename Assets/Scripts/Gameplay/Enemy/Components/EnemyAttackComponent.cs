using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class EnemyAttackComponent
    {
        private readonly NavMeshAgent _agent;
        private readonly EnemyStateManager _stateManager;
        private readonly Animator _animator;
        private readonly string[] _attackAnimations;

        public EnemyAttackComponent(NavMeshAgent agent, EnemyStateManager stateManager, Animator animator,
            string[] attackAnimations)
        {
            _agent = agent;
            _stateManager = stateManager;
            _animator = animator;
            _attackAnimations = attackAnimations;
        }

        public void Attack()
        {
            if (_stateManager.IsAttacking && !_stateManager.IsBusy)
            {
                _animator.Play(GetAttackAnimationName());
                _stateManager.IsBusy = true;
                _agent.isStopped = true;
            }
        }

        private string GetAttackAnimationName()
        {
            int rand = Random.Range(0, _attackAnimations.Length);
            return _attackAnimations[rand];
        }
    }
}