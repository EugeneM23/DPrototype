using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerAnimationBehaviour : ITickable
    {
        private readonly Animator _animator;
        private readonly CharacterController _characterController;

        public PlayerAnimationBehaviour(Animator animator, CharacterController characterController)
        {
            _animator = animator;
            _characterController = characterController;
        }

        public void Tick()
        {
            if (_characterController.velocity != Vector3.zero)
                _animator.SetBool("IsRuning", true);
            else
            {
                _animator.SetBool("IsIdling", true);
                _animator.SetBool("IsRuning", false);
            }
        }

        public void Shoot()
        {
            _animator.SetTrigger("Shoot");
            _animator.SetBool("IsIdling", false);

            _animator.SetBool("IsFiring", true);
        }

        public void StopShoot()
        {
            _animator.SetBool("IsFiring", false);
        }
    }
}