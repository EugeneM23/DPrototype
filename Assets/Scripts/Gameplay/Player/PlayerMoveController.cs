using Zenject;

namespace Gameplay
{
    public class PlayerMoveController : ITickable
    {
        private readonly Player _player;
        private readonly PlayerInput _playerInput;

        public PlayerMoveController(Player player, PlayerInput playerInput)
        {
            _player = player;
            _playerInput = playerInput;
        }

        public void Tick()
        {
            _player.Move(_playerInput.Axis);
        }
    }
}