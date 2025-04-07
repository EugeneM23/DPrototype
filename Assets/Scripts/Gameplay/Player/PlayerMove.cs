using UnityEngine;

namespace Gameplay
{
    internal class PlayerMove
    {
        private readonly CharacterController _characterController;
        private readonly float _speed;

        public PlayerMove(Player player, float speed)
        {
            _speed = speed;
            _characterController = player.GetComponent<CharacterController>();
        }

        public void Move(Vector3 direction)
        {
            direction += Physics.gravity;
            _characterController.Move(direction * _speed * Time.deltaTime);
        }
    }
}