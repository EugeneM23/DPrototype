using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerAnimationController : ITickable
    {
        private readonly Animator _animator;
        private readonly Player _player;

        public PlayerAnimationController(Player player)
        {
            _player = player;
            _animator = _player.Animator;
        }

        public void Tick()
        {
            if (_player.GetVelocity() != Vector3.zero)
                _animator.SetBool("IsRuning", true);
            else
            {
                _animator.SetBool("IsIdling", true);
                _animator.SetBool("IsRuning", false);
            }
        }

        public void Shoot()
        {
            _animator.SetBool("IsIdling", false);

            _animator.SetBool("IsFiring", true);
        }

        public void StopShoot()
        {
            _animator.SetBool("IsFiring", false);

        }
    }
}