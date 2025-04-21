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

        [Inject] private WeaponSetings _setings;
        [Inject] private IBulletSpawner _bulletSpawner;
        [Inject] private IShellSpawner _shellSpawner;
        [Inject] private CameraShakeComponent _cameraShake;
        [Inject] private PlayerAnimationController _animationController;

        private bool _readyToFire;
        private float lastTimeShoot = 0;

        private void Update() => CoolDown();

        public void Shoot(Transform targer)
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
                _animationController.StopShoot();
                _readyToFire = true;
            }
        }

        public float GetFireRange()
        {
            return _setings.FireRange;
        }
    }
}