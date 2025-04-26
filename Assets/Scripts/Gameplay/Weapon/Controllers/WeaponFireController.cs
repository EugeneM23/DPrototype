using DPrototype.Game;
using Zenject;

namespace Game
{
    public class WeaponFireController : IInitializable
    {
        private readonly Player _player;
        private readonly Weapon _weapon;
        private readonly PlayerCamera _camera;

        public WeaponFireController(Player player, Weapon weapon, PlayerCamera camera)
        {
            _player = player;
            _weapon = weapon;
            _camera = camera;
        }

        public void Initialize()
        {
            _player.OnShoot += _weapon.Shoot;
            _player.OnShoot += () => _camera.Shake(_weapon.ShakeMagnitude, _weapon.ShakeDuration);
        }
    }
}