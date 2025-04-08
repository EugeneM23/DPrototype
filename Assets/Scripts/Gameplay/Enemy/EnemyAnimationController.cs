using Gameplay.BehComponents;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyAnimationController : ITickable
    {
        private readonly Animator _animator;
        private readonly EnemyConditions _conditions;

        public EnemyAnimationController(Animator animator, EnemyConditions conditions)
        {
            _animator = animator;
            _conditions = conditions;
        }

        public void Tick()
        {
            _animator.SetBool("IsWalking", _conditions.IsPatroling);
            _animator.SetBool("IsRunning", _conditions.IsChasing);
            _animator.SetBool("IsAttaking", _conditions.IsAttaking);
        }
    }
}