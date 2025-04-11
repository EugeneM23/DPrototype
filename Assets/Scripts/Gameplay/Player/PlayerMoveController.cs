using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerMoveController : ITickable
    {
        private readonly Player _player;
        private readonly PlayerInput _playerInput;
        private Vector3 pushDirection;
        private float pushForce = 5;
        private bool swipe;

        public PlayerMoveController(Player player, PlayerInput playerInput)
        {
            _player = player;
            _playerInput = playerInput;
        }

        public void Tick()
        {
            Vector3 move = new Vector3(0, 0, 0);
            if (!swipe)
                move = _playerInput.Axis.normalized;

            _player.Move(move + pushDirection);

            if (pushDirection.sqrMagnitude < 1)
            {
                pushDirection = Vector3.zero;
                swipe = false;
            }

            pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, Time.deltaTime * 6);
        }

        public void ApplyImpulse(Vector3 direction)
        {
            swipe = true;
            pushDirection = direction * pushForce;
        }
    }
}