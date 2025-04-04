using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class CameraFolower : ILateTickable
    {
        private readonly Player _target;
        private readonly Transform _camera;
        private readonly Vector3 _offset;
        private readonly float _smoothTime = 0.15f;
        private Vector3 _velocity = Vector3.zero;

        public CameraFolower(Transform camera, Player target)
        {
            _camera = camera;
            _target = target;
            _offset = Camera.main.transform.position - _target.transform.position;
        }

        public void LateTick()
        {
            Vector3 targetPosition = _target.transform.position + _offset;
            _camera.position = Vector3.SmoothDamp(_camera.position, targetPosition, ref _velocity, _smoothTime);
        }
    }
}