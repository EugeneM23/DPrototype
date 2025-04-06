using UnityEngine;

namespace Gameplay
{
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private Enemy _enemy;

        private void Update()
        {
            _animator.SetBool("IsRunning", _enemy.IsRuning);
            _animator.SetBool("IsWalking", _enemy.IsWalking);
            _animator.SetBool("IsAidling", _enemy.IsAidling);
            _animator.SetBool("IsAttaking", _enemy.IsAttaking);
        }

        public void SetEnemy(Enemy enemy)
        {
            _enemy = enemy;
        }
    }
}