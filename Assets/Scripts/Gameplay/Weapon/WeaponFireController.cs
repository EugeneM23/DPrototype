using System;
using Zenject;

namespace Gameplay
{
    public class WeaponFireController : IInitializable, IDisposable
    {
        private Weapon _weapon;
        private readonly PlayerAnimationBehaviour _animationBehaviour;
        private readonly CameraShakeComponent _cameraShake;

        public WeaponFireController(Weapon weapon, PlayerAnimationBehaviour animationBehaviour,
            CameraShakeComponent cameraShake)
        {
            _weapon = weapon;
            _animationBehaviour = animationBehaviour;
            _cameraShake = cameraShake;
        }

        public void Initialize()
        {
            _weapon.OnFire += () => _cameraShake.CameraShake(_weapon.ShakeMagnitude, _weapon.ShakeDuration);
            _weapon.OnFire += _animationBehaviour.Shoot;
        }

        public void Dispose()
        {
            _weapon.OnFire -= _animationBehaviour.Shoot;
        }
    }
}