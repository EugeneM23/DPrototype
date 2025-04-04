using UnityEngine;

namespace Gameplay
{
    internal class PlayerLookAtComponent
    {
        private readonly Player _player;
        private readonly float _aimingSpeed;

        public PlayerLookAtComponent(Player player, float aimingSpeed)
        {
            _player = player;
            _aimingSpeed = aimingSpeed;
        }

        public void LookAt(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - _player.transform.position;
            direction.y = 0f;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                _player.transform.rotation = Quaternion.RotateTowards(_player.transform.rotation, targetRotation,
                    _aimingSpeed * Time.deltaTime);
            }
        }
    }
}