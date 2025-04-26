using DPrototype.Game;

namespace Game
{
    public class PlayerCameraController
    {
        private readonly PlayerCamera _camera;
        private readonly PlayerTransform _playerTransform;

        public PlayerCameraController(PlayerCamera camera, PlayerTransform playerTransform)
        {
            _camera = camera;
            _playerTransform = playerTransform;

            _camera.SetTarget(_playerTransform.transform);
        }
    }
}