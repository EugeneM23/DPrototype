using System;
using System.Collections;
using Modules;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private bool _isPushableBullet;
        [SerializeField] private float _impulsPower;
        [SerializeField] private float _impulsTime;

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

        private void OnCollisionEnter(Collision target)
        {
            if (target.gameObject.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_bulletDamage.Damage);

            if (target.gameObject.TryGetComponent(out PushableObject pushable) && _isPushableBullet)
            {
                pushable.SetImpulse(transform.forward, _impulsPower, _impulsTime);
            }

            if (_bulletRicochet.CanRicochet)
            {
                var direction = _bulletRicochet.Ricochet(target);
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