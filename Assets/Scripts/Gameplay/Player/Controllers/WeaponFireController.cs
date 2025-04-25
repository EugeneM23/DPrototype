using System;
using Zenject;

namespace Gameplay
{
    public class WeaponFireController : IInitializable, IDisposable
    {
        private IWeapon _weapon;
        private readonly PlayerAnimationBehaviour _animationBehaviour;

        public WeaponFireController(IWeapon weapon, PlayerAnimationBehaviour animationBehaviour)
        {
            _weapon = weapon;
            _animationBehaviour = animationBehaviour;
        }

        public void Initialize()
        {
            _weapon.OnFire += _animationBehaviour.Shoot;
        }

        public void Dispose()
        {
            _weapon.OnFire -= _animationBehaviour.Shoot;
        }
    }
}