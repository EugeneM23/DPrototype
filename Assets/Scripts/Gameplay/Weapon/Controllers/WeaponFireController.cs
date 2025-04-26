using DPrototype.Game;
using UnityEngine;
using Zenject;

namespace Game
{
    public class WeaponFireController : IInitializable
    {
        private readonly Player _player;
        private readonly Weapon _weapon;
        private readonly CameraController _cameraController;

        public WeaponFireController(Player player, Weapon weapon, CameraController cameraController)
        {
            _player = player;
            _weapon = weapon;
            _cameraController = cameraController;
        }

        public void Initialize()
        {
            _player.OnShoot += _weapon.Shoot;
            _player.OnShoot += () => _cameraController.Shake(_weapon.ShakeMagnitude, _weapon.ShakeDuration);
        }
    }
}