using Modules;

namespace Gameplay
{
    public class PlayerCameraController
    {
        private readonly ObjectFollowComponent _cameraController;
        private readonly PlayerTransform _playerTransform;

        public PlayerCameraController(ObjectFollowComponent cameraController, PlayerTransform playerTransform)
        {
            _cameraController = cameraController;
            _playerTransform = playerTransform;

            _cameraController.SetTarget(_playerTransform.transform);
        }
    }
}