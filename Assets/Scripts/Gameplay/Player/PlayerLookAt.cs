using UnityEngine;

namespace Gameplay
{
    internal class PlayerLookAt
    {
        private readonly Player _player;
        private readonly float _aimingSpeed;

        public PlayerLookAt(Player player, float aimingSpeed)
        {
            _player = player;
            _aimingSpeed = aimingSpeed;
        }

        public bool LookAtAndCheck(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - _player.transform.position;
            direction.y = 0f;

            if (direction == Vector3.zero)
                return true;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            
            _player.transform.rotation = Quaternion.RotateTowards(_player.transform.rotation, targetRotation,
                _aimingSpeed * Time.deltaTime);

            float angle = Quaternion.Angle(_player.transform.rotation, targetRotation);
            return angle < 1f;
        }
    }
}