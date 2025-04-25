using Zenject;

namespace Game
{
    public class PlayerMoveController : ITickable
    {
        private readonly Player _player;
        private readonly PlayerInput _playerInput;

        public PlayerMoveController(PlayerInput playerInput, Player player)
        {
            _player = player;
            _playerInput = playerInput;
        }

        public void Tick()
        {
            _player.Move(_playerInput.Axis.normalized);
        }
    }
}