using DPrototype.Game;
using Zenject;

namespace Gameplay
{
    public class WeaponFireController : IInitializable
    {
        private readonly Player _player;
        private readonly Weapon _weapon;
        private readonly CameraShakeComponent _cameraShakeComponent;

        public WeaponFireController(Player player, Weapon weapon, CameraShakeComponent cameraShakeComponent)
        {
            _player = player;
            _weapon = weapon;
            _cameraShakeComponent = cameraShakeComponent;
        }

        public void Initialize()
        {
            _player.OnShoot += _weapon.Shoot;
            _player.OnShoot += () => _cameraShakeComponent.CameraShake(_weapon.ShakeMagnitude, _weapon.ShakeDuration);
        }
    }
}