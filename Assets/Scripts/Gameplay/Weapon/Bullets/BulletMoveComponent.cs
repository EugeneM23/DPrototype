using UnityEngine;

namespace Gameplay
{
    public class BulletMoveComponent
    {
        private readonly Transform _bulletTransform;
        private float _speed;
        private Vector3 _direction;

        public BulletMoveComponent(Transform bulletTransform)
        {
            _bulletTransform = bulletTransform;
        }

        public void Move() => _bulletTransform.position += _direction * Time.deltaTime * _speed;

        public void SetSpeed(float speed) => _speed = speed;

        public void SetDirection(Vector3 direction) => _direction = direction;
    }
}