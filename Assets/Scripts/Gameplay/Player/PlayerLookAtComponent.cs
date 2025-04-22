using UnityEngine;

namespace Gameplay
{
    public class PlayerLookAtComponent
    {
        private readonly PlayerTransform _player;
        private readonly float _aimingSpeed;

        public PlayerLookAtComponent(PlayerTransform player, float aimingSpeed)
        {
            _player = player;
            _aimingSpeed = aimingSpeed;
        }

        public bool LookAtAndCheck(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - _player.Player.position;
            direction.y = 0f;

            if (direction == Vector3.zero)
                return true;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            _player.Player.rotation = Quaternion.RotateTowards(_player.Player.rotation, targetRotation,
                _aimingSpeed * Time.deltaTime);

            float angle = Quaternion.Angle(_player.Player.rotation, targetRotation);
            bool asd = angle < 1f;

            return asd;
        }
    }
}