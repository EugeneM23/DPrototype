using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerWeponController : IInitializable
    {
        private Weapon _weapon;
        private DiContainer _container;
        private Player _player;

        public PlayerWeponController(Player player, Weapon weapon, DiContainer container)
        {
            _player = player;
            _weapon = weapon;
            _container = container;
        }

        public void Initialize() => SetWeapon();

        public void SetWeapon()
        {
            Weapon weapon = _container.InstantiatePrefab(_weapon).GetComponent<Weapon>();
            _player.SetWeapon(weapon);
        }
    }
}