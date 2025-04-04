using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class CameraFolower : ILateTickable
    {
        private readonly Player _target;
        private readonly Transform _camera;
        private readonly Vector3 _offset;

        public CameraFolower(Transform camera, Player target)
        {
            _camera = camera;
            _target = target;
            _offset = Camera.main.transform.position - _target.transform.position;
        }

        public void LateTick()
        {
            _camera.position = _target.transform.position + _offset;
        }
    }
}