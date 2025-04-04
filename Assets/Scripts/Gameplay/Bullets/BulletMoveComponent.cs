using UnityEngine;

namespace Gameplay
{
    internal class BulletMoveComponent : MonoBehaviour
    {
        private float _speed;

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void Move(Vector3 moveDirection)
        {
            transform.position += moveDirection * Time.deltaTime * _speed;
        }
    }
}