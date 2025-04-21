using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnDispose;

        [SerializeField] private BulletRicochetComponent _ricochetComponent;

        private BulletMoveComponent _bulletMoveComponent;

        private Vector3 _moveDirection;
        private int _damage;

        [Inject]
        public void Construct(BulletMoveComponent moveComponent)
        {
            _bulletMoveComponent = moveComponent;
        }

        private void Update()
        {
            _bulletMoveComponent.Move(_moveDirection);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out IDamagable damageable))
                damageable.TakeDamage(_damage);

            if (_ricochetComponent.CanRicochet)
            {
                _moveDirection = _ricochetComponent.CalculateRicochetDirection(other, _moveDirection);
                return;
            }

            Dispose();
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        public void Dispose() => OnDispose?.Invoke(this);

        public void Setup(int damage, float bulletSpeed, Vector3 direction)
        {
            _damage = damage;
            _moveDirection = direction;
            _bulletMoveComponent.SetSpeed(bulletSpeed);
        }
    }
}