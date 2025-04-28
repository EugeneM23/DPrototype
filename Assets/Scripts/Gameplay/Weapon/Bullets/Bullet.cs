using System;
using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private bool _isPushableBullet;
        [SerializeField] private float _impulsePower;
        [SerializeField] private float _lostImpulseOverTime;
        [SerializeField] private float _maxImpulseForce;
        [SerializeField] private float _impulseDuration;

        public event Action<Bullet> OnDispose;

        private BulletRicochetComponent _bulletRicochet;
        private BulletMoveComponent _bulletMove;
        private BulletDamageComponent _bulletDamage;
        private float _lifeTime;

        [Inject]
        public void Construct(BulletMoveComponent moveComponent, BulletRicochetComponent ricochetComponent,
            BulletDamageComponent damageComponent)
        {
            _bulletMove = moveComponent;
            _bulletRicochet = ricochetComponent;
            _bulletDamage = damageComponent;
        }

        private void OnEnable()
        {
            _lifeTime = 0.01f;
        }

        private void Update()
        {
            _lifeTime += Time.deltaTime * _lostImpulseOverTime;
            _bulletMove.Move();
        }

        public void Setup(int damage, float bulletSpeed, Vector3 direction)
        {
            _bulletDamage.SetDamage(damage);
            _bulletMove.SetSpeed(bulletSpeed);
            _bulletMove.SetDirection(direction);
            _bulletRicochet.Reset();
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
        }

        private void OnCollisionEnter(Collision collision)
        {
            HandleDamage(collision);
            HandlePush(collision);

            if (HandleRicochet(collision))
                return;

            Dispose();
        }

        private void HandleDamage(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(_bulletDamage.Damage);
            }
        }

        private void HandlePush(Collision collision)
        {
            if (!_isPushableBullet)
                return;

            if (collision.gameObject.TryGetComponent<PushableObject>(out var pushable))
            {
                float rawImpulseForce = _impulsePower / _lifeTime;
                float clampedImpulseForce = Mathf.Min(rawImpulseForce, _maxImpulseForce); // Ограничение силы
                pushable.SetImpulse(transform.forward, clampedImpulseForce, _impulseDuration);
            }
        }

        private bool HandleRicochet(Collision collision)
        {
            if (!_bulletRicochet.CanRicochet)
                return false;

            Vector3 newDirection = _bulletRicochet.Ricochet(collision);
            _bulletMove.SetDirection(newDirection);
            return true;
        }

        private void Dispose()
        {
            OnDispose?.Invoke(this);
        }
    }
}