using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyAnimationController : ITickable
    {
        private readonly Animator _animator;
        private readonly EnemyStateObserver _conditions;
        //private readonly string[] _attackTnimations;

        public EnemyAnimationController(Animator animator, EnemyStateObserver conditions,
            AttackComponent attackComponent)
        {
            _animator = animator;
            _conditions = conditions;
            attackComponent.OnAttacked += Attack;
        }

        public void Tick()
        {
            _animator.SetBool("IsWalking", _conditions.IsPatroling);
            _animator.SetBool("IsRunning", _conditions.IsChasing);
            _animator.SetBool("IsAttaking", _conditions.IsAttaking);
        }

        private void Attack()
        {
            if (_conditions.IsAttaking) return;

            //if (_attackTnimations.Length == 0) return;

            /*int rand = Random.Range(0, _attackTnimations.Length);
            _animator.Play(_attackTnimations[rand]);*/
        }
    }
}