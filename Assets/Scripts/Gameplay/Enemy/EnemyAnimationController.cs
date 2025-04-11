using Gameplay.BehComponents;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyAnimationController : ITickable, IInitializable
    {
        private readonly Animator _animator;
        private readonly EnemyConditions _conditions;
        private readonly string[] _attackTnimations;

        public EnemyAnimationController(Animator animator, EnemyConditions conditions, AttackComponent attackComponent,
            string[] attackTnimations)
        {
            _animator = animator;
            _conditions = conditions;
            _attackTnimations = attackTnimations;
            attackComponent.OnAttacked += Attack;
        }

        public void Tick()
        {
            _animator.SetBool("IsWalking", _conditions.IsPatroling);
            _animator.SetBool("IsRunning", _conditions.IsChasing);
            //_animator.SetBool("IsAttaking", _conditions.IsAttaking);
        }

        private void Attack()
        {
            if (_conditions.IsAttaking) return;

            int rand = Random.Range(0, _attackTnimations.Length);
            _animator.Play(_attackTnimations[rand]);
        }

        public void Initialize()
        {
        }
    }
}