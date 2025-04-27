using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyAnimationBehaviour : ITickable
    {
        private readonly Animator _animator;
        private readonly EnemyStateManager _conditions;

        private static readonly int IsWalkingHash = Animator.StringToHash("IsWalking");
        private static readonly int IsRunningHash = Animator.StringToHash("IsRunning");
        private static readonly int IsAttackingHash = Animator.StringToHash("IsAttaking");

        public EnemyAnimationBehaviour(Animator animator, EnemyStateManager conditions)
        {
            _animator = animator;
            _conditions = conditions;
        }

        public void Tick()
        {
            if (_conditions.IsBusy) return;
            
            _animator.SetBool(IsWalkingHash, _conditions.IsPatroling);
            _animator.SetBool(IsRunningHash, _conditions.IsChasing);
            _animator.SetBool(IsAttackingHash, _conditions.IsAttacking);
        }
    }
}