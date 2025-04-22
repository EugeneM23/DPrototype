using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        public event Action OnFire;

        [SerializeField] private Transform _firePoint;
        [SerializeField] private Transform _shellPoint;
        [SerializeField] private WeaponSetings _setings;

        private IBulletSpawner _bulletSpawner;
        private IShellSpawner _shellSpawner;

        private bool _readyToFire;
        private float lastTimeShoot = 0;

        private void Update() => CoolDown();

        [Inject]
        public void Construct(IBulletSpawner bulletSpawner, IShellSpawner shellSpawner)
        {
            _bulletSpawner = bulletSpawner;
            _shellSpawner = shellSpawner;
        }

        public void Shoot()
        {
            if (_readyToFire)
            {
                _readyToFire = false;
                OnFire?.Invoke();

                Shell shell = _shellSpawner.Create(_shellPoint.position, _shellPoint.rotation);
                shell.SetVelocity(_shellPoint.up + _shellPoint.right);

                Bullet bullet = _bulletSpawner.Create(_firePoint.position, _firePoint.rotation);
                bullet.Setup(_setings.Damage, _setings.BulletSpeed, _firePoint.forward);

                lastTimeShoot = _setings.FireRate;
            }
        }

        private void CoolDown()
        {
            lastTimeShoot -= Time.deltaTime;

            if (lastTimeShoot <= 0)
            {
                //_animationController.StopShoot();
                _readyToFire = true;
            }
        }

        public float GetFireRange()
        {
            return _setings.FireRange;
        }
    }
}