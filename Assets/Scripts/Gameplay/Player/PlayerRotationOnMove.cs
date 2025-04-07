using UnityEngine;

namespace Gameplay
{
    internal class PlayerRotationOnMove
    {
        private readonly Player _player;
        private readonly float _speed;

        public PlayerRotationOnMove(Player player, float speed)
        {
            _player = player;
            _speed = speed;
        }

        public void Ratation(Vector3 direction)
        {
            if (direction.sqrMagnitude > 0.001f)
            {
                direction.Normalize();

                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

                _player.transform.rotation =
                    Quaternion.Slerp(_player.transform.rotation, targetRotation, _speed * Time.deltaTime);
            }
        }
    }
}