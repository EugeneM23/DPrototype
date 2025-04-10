using System;
using UnityEngine;

namespace Gameplay
{
    public class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnDispose;

        [SerializeField] private BulletMoveComponent _bulletMoveComponent;

        private Vector3 _moveDirection;
        private int _damage;

        private void Update() => _bulletMoveComponent.Move(_moveDirection);

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out IDamagable damageable))
                damageable.TakeDamage(_damage);

            Destroy(this.gameObject);
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

        public void Destroy(GameObject gameObject) => OnDispose?.Invoke(this);
    }
}