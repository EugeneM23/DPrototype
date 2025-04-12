using System;
using UnityEngine;

namespace Gameplay
{
    public class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnDispose;

        [SerializeField] private BulletMoveComponent _bulletMoveComponent;
        [SerializeField] private BulletRicochetComponent _ricochetComponent;

        private Vector3 _moveDirection;
        private int _damage;

        private void Update() => _bulletMoveComponent.Move(_moveDirection);

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

        public void Construct(int damage, PhysicsLayer physicsLayer, float speed, Vector3 moveDirection)
        {
            _moveDirection = moveDirection;
            _damage = damage;
            gameObject.layer = (int)physicsLayer;
            _bulletMoveComponent.SetSpeed(speed);
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        public void Dispose() => OnDispose?.Invoke(this);
    }
}