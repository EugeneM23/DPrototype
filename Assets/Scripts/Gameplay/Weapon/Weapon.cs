using System;
using Gameplay;
using UnityEngine;
using Zenject;

namespace Game
{
    public class Weapon : ITickable
    {
        public event Action OnFire;

        private Transform _firePoint;
        private Transform _shellPoint;
        private WeaponSetings _setings;
        public float ShakeDuration => _setings.ShakeDuration;
        public float ShakeMagnitude => _setings.ShakeMagnitude;

        private IBulletSpawner _bulletSpawner;
        private IShellSpawner _shellSpawner;

        private bool _readyToFire;

        private float lastTimeShoot = 0;

        public Weapon(IBulletSpawner bulletSpawner, IShellSpawner shellSpawner, WeaponSetings setings,
            Transform firePoint, Transform shellPoint)
        {
            _bulletSpawner = bulletSpawner;
            _shellSpawner = shellSpawner;
            _setings = setings;
            _shellPoint = shellPoint;
            _firePoint = firePoint;
        }

        public void Tick()
        {
            CoolDown();
        }

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