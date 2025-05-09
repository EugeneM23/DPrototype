using UnityEngine;

namespace Modules
{
    public class MoveComponent
    {
        private readonly CharacterController _characterController;
        private readonly float _speed;

        public MoveComponent(float speed, CharacterController characterController)
        {
            _speed = speed;
            _characterController = characterController;
        }

        public void Move(Vector3 direction)
        {
            direction += Physics.gravity;
            _characterController.Move(direction * _speed * Time.deltaTime);
        }
    }
}