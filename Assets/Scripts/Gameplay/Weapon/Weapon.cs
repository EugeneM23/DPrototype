using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Weapon : ITickable, IInitializable, IWeapon
    {
        public event Action OnFire;

        private Transform _firePoint;
        private Transform _shellPoint;
        private WeaponSetings _setings;
        private PlayerWeponController _playerWeponController;
        public float ShakeDuration => _setings.ShakeDuration;
        public float ShakeMagnitude => _setings.ShakeMagnitude;

        private IBulletSpawner _bulletSpawner;
        private IShellSpawner _shellSpawner;

        private bool _readyToFire;

        public Weapon(IBulletSpawner bulletSpawner, IShellSpawner shellSpawner, WeaponSetings setings,
            Transform firePoint, Transform shellPoint, PlayerWeponController playerWeponController)
        {
            _bulletSpawner = bulletSpawner;
            _shellSpawner = shellSpawner;
            _setings = setings;
            _shellPoint = shellPoint;
            _playerWeponController = playerWeponController;
            _firePoint = firePoint;
        }

        public void Initialize()
        {
            _playerWeponController.SetWeapon(this);
        }

        private float lastTimeShoot = 0;

        public void Tick() => CoolDown();

        public void Shoot()
        {
            if (_readyToFire)
            {
                _readyToFire = false;
                OnFire?.Invoke();

                _shellSpawner.Create(_shellPoint.position, _shellPoint.rotation, _setings.ShellImpulse,
                    _setings.ImpulsePower);

                Bullet bullet = _bulletSpawner.Create(_firePoint.position, _firePoint.rotation);
                bullet.Setup(_setings.Damage, _setings.BulletSpeed, _firePoint.forward);

                lastTimeShoot = _setings.FireRate;
            }
        }

        private void CoolDown()
        {
            lastTimeShoot -= Time.deltaTime;

            if (lastTimeShoot <= 0)
                _readyToFire = true;
        }

        public float GetFireRange()
        {
            return _setings.FireRange;
        }
    }
}