using System;
using System.Collections;
using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnDispose;

        private BulletRicochetComponent _bulletRicochet;
        private BulletMoveComponent _bulletMove;
        private BulletDamageComponent _bulletDamage;

        [Inject]
        public void Construct(BulletMoveComponent moveComponent, BulletRicochetComponent ricochetComponent,
            BulletDamageComponent bulletDamage)
        {
            _bulletMove = moveComponent;
            _bulletRicochet = ricochetComponent;
            _bulletDamage = bulletDamage;
        }

        private void Update() => _bulletMove.Move();

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_bulletDamage.Damage);

            if (_bulletRicochet.CanRicochet)
            {
                var direction = _bulletRicochet.Ricochet(other);
                _bulletMove.SetDirection(direction);
                return;
            }

            OnDispose?.Invoke(this);
        }

        public void Setup(int damage, float bulletSpeed, Vector3 direction)
        {
            _bulletDamage.SetDamage(damage);
            _bulletMove.SetSpeed(bulletSpeed);
            _bulletMove.SetDirection(direction);
            _bulletRicochet.Reset();
        }
    }
}