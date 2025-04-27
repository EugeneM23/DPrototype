using System;
using Gameplay;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class Weapon : ITickable
    {
        public event Action OnFire;

        private readonly Transform _firePoint;
        private readonly Transform _shellPoint;
        private readonly WeaponSetings _setings;
        private readonly Player _player;
        public float ShakeDuration => _setings.ShakeDuration;
        public float ShakeMagnitude => _setings.ShakeMagnitude;

        private IBulletSpawner _bulletSpawner;
        private IShellSpawner _shellSpawner;

        private bool _readyToFire;

        private float lastTimeShoot = 0;

        public Weapon(IBulletSpawner bulletSpawner, IShellSpawner shellSpawner, WeaponSetings setings,
            Transform firePoint, Transform shellPoint, Player player)
        {
            _bulletSpawner = bulletSpawner;
            _shellSpawner = shellSpawner;
            _setings = setings;
            _shellPoint = shellPoint;
            _player = player;
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

                for (int i = 0; i < _setings.ProjectileCount; i++)
                {
                    Quaternion rotation = CalculatRotation();

                    Bullet bullet = _bulletSpawner.Create(_firePoint.position, rotation);
                    bullet.Setup(_setings.Damage, _setings.BulletSpeed, bullet.transform.forward);
                }

                lastTimeShoot = _setings.FireRate;
            }
        }

        private void CoolDown()
        {
            lastTimeShoot -= Time.deltaTime;

            if (lastTimeShoot <= 0)
                _readyToFire = true;
        }

        private Quaternion CalculatRotation()
        {
            Vector3 targetPosition = _player.GetTarget().position + Vector3.up * 1.5f;

            Vector3 directionToTarget = (targetPosition - _firePoint.position).normalized;

            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
            float randomY = Random.Range(-_setings.Scatter, _setings.Scatter);
            Quaternion scatterRotation = Quaternion.Euler(0f, randomY, 0f);
            Quaternion finalRotation = scatterRotation * lookRotation;
            return finalRotation;
        }
    }
}