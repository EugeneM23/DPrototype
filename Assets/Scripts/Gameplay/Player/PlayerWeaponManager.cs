using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayerWeaponManager
    {
        DiContainer _container;
        private GameObject _weaponPrefab;
        public GameObject CurrentWeapon { get; private set; }

        public PlayerWeaponManager(DiContainer container, GameObject weaponPrefab)
        {
            _container = container;
            _weaponPrefab = weaponPrefab;
            CurrentWeapon = _container.InstantiatePrefab(_weaponPrefab);
        }
    }
}