using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyAnimationBehaviour : ITickable
    {
        private readonly Animator _animator;
        private readonly EnemyStateManager _conditions;

        public EnemyAnimationBehaviour(Animator animator, EnemyStateManager conditions)
        {
            _animator = animator;
            _conditions = conditions;
        }

        public void Tick()
        {
            if (_conditions.IsBusy) return;

            _animator.SetBool("IsWalking", _conditions.IsPatroling);
            _animator.SetBool("IsRunning", _conditions.IsChasing);
            _animator.SetBool("IsAttaking", _conditions.IsAttacking);
        }
    }
}