using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private WeaponData _data;
        [SerializeField] private Transform _firePoint;

        [Inject] private IBulletSpawner _bulletSpawner;
        private bool _readyToFire;
        private float lastTimeShoot = 0;

        private void Update()
        {
            CoolDown();
        }

        public void Shoot(Transform targer)
        {
            Debug.Log("sadas");

            if (_readyToFire)
            {
                _readyToFire = false;
                Quaternion bulletRotation = Quaternion.LookRotation(_firePoint.forward);
                Bullet bullet = _bulletSpawner.Create(_firePoint.position, _firePoint.rotation);
                bullet.Construct(_data._bulletInfo.Damage, PhysicsLayer.PLAYER_BULLET, _data._bulletInfo.BulletSpeed, _firePoint.forward);
                lastTimeShoot = _data.FireRate;
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
            return _data.FireRange;
        }
    }
}