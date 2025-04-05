using System;
using Gameplay.Common;
using Modules.PrefabPool;
using UnityEngine;

namespace Gameplay
{
    public class Bullet : MonoBehaviour, IDespawned
    {
        public event Action<GameObject> DeSpawn;

        [SerializeField] private BulletMoveComponent _bulletMoveComponent;

        private bool _collisionEnable = true;
        private Vector3 _moveDirection;
        private int _damage;

        private void OnEnable() => _collisionEnable = true;

        private void Update() => _bulletMoveComponent.Move(_moveDirection);

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out IDamagable damageable)) 
                damageable.TakeDamage(_damage);
            
            Destroy();
        }

        public void Construct(int damage, PhysicsLayer physicsLayer, float speed)
        {
            _damage = damage;
            gameObject.layer = (int)physicsLayer;
            _bulletMoveComponent.SetSpeed(speed);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetMoveDirection(Vector3 moveDirection)
        {
            _moveDirection = moveDirection;
        }

        public void Destroy()
        {
            DeSpawn?.Invoke(gameObject);
        }
    }

    internal interface IDamageable
    {
        void TakeDamage(int damage);
    }
}