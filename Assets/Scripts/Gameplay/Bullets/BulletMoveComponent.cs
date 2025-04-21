using UnityEngine;

namespace Gameplay
{
    public class BulletMoveComponent
    {
        private readonly Transform _bullet;
        private float _speed;

        public BulletMoveComponent(Transform bullet)
        {
            _bullet = bullet;
        }
        public void Move(Vector3 moveDirection)
        {
            _bullet.position += moveDirection * Time.deltaTime * _speed;
        }

        public void SetSpeed(float speed)
        {

            _speed = speed;
        }
    }
}