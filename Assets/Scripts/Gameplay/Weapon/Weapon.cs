using UnityEngine;
using Zenject;

namespace Gameplay.Weapon
{
    internal class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private WeaponData _data;
        [SerializeField] private Transform _firePoint;

        [Inject] private Bulletmanager _bulletmanager;
        private bool _readyToFire;
        private float lastTimeShoot = 0;

        private void Update()
        {
            CoolDown();
        }

        public void Shoot(Transform targer)
        {
            if (_readyToFire)
            {
                _readyToFire = false;
                _bulletmanager.SpawnBullet(_data._bulletInfo, _firePoint.position, _firePoint.forward);
                lastTimeShoot = _data.FireRate;
            }
        }

        private void CoolDown()
        {
            lastTimeShoot -= Time.deltaTime;

            if (lastTimeShoot <= 0)
                _readyToFire = true;
        }
    }
}