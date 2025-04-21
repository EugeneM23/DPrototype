using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerWeponController : IInitializable
    {
        private Player _player;
        private Weapon _weapon;

        private DiContainer _container;

        public PlayerWeponController(Player player, Weapon weapon, DiContainer container)
        {
            _player = player;
            _weapon = weapon;
            _container = container;
        }

        public void SetWeapon()
        {
            Weapon weapon = _container.InstantiatePrefab(_weapon).GetComponent<Weapon>();
            _player.SetWeapon(weapon);
        }

        public void Initialize()
        {
            SetWeapon();
        }
    }
}