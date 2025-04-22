using UnityEngine;

namespace Gameplay
{
    public class PlayerRotationOnMoveComponent
    {
        private readonly PlayerTransform _player;
        private readonly float _speed;

        public PlayerRotationOnMoveComponent(PlayerTransform player, float speed)
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

                _player.Player.rotation =
                    Quaternion.Slerp(_player.Player.rotation, targetRotation, _speed * Time.deltaTime);
            }
        }
    }
}