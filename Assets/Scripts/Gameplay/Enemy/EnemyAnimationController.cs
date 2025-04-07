using UnityEngine;

namespace Gameplay
{
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private EnemyStateMachine _stateMachine;

        private void Update()
        {
            _animator.SetBool("IsRunning", _stateMachine.IsRuning);
            _animator.SetBool("IsWalking", _stateMachine.IsWalking);
            _animator.SetBool("IsAidling", _stateMachine.IsAidling);
            _animator.SetBool("IsAttaking", _stateMachine.IsAttaking);
        }
    }
}