using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponFireController : IInitializable, IDisposable
    {
        private Weapon _weapon;
        private readonly PlayerAnimationController _animationController;
        private readonly CameraShakeComponent _cameraShake;

        public WeaponFireController(Weapon weapon, PlayerAnimationController animationController,
            CameraShakeComponent cameraShake)
        {
            _weapon = weapon;
            _animationController = animationController;
            _cameraShake = cameraShake;
        }

        public void Initialize()
        {
            _weapon.OnFire += () => _cameraShake.CameraShake(_weapon.ShakeMagnitude, _weapon.ShakeDuration);
            _weapon.OnFire += _animationController.Shoot;
        }

        private void CameraShake(float shakeMagnitude, float shakeDuration)
        {
        }

        public void Dispose()
        {
            _weapon.OnFire -= _animationController.Shoot;
        }
    }
}