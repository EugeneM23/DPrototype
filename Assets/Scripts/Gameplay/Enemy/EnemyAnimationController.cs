using Gameplay.BehComponents;
using UnityEngine;

namespace Gameplay
{
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private EnemyConditions _conditions;

        private void Update()
        {
            _animator.SetBool("IsWalking", _conditions.IsPatroling);
            _animator.SetBool("IsRunning", _conditions.IsChasing);
            _animator.SetBool("IsAttaking", _conditions.IsAttaking);
            /*
            _animator.SetBool("IsAidling", _stateMachine.IsAidling);
            _animator.SetBool("IsAttaking", _stateMachine.IsAttaking);#1#
        */
        }
    }
}