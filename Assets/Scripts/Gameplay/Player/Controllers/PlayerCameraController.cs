using DPrototype.Game;

namespace Game
{
    public class PlayerCameraController
    {
        private readonly DPrototype.Game.CameraController _cameraController;
        private readonly PlayerTransform _playerTransform;

        public PlayerCameraController(DPrototype.Game.CameraController cameraController, PlayerTransform playerTransform)
        {
            _cameraController = cameraController;
            _playerTransform = playerTransform;

            _cameraController.SetTarget(_playerTransform.transform);
        }
    }
}