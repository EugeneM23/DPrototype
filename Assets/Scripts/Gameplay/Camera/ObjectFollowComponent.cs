using Game;
using UnityEngine;

namespace Modules
{
    public class ObjectFollowComponent
    {
        private readonly PlayerTransform _target;
        private readonly Transform _main;
        private readonly Vector3 _offset;
        private readonly float _smoothTime;

        private Vector3 _velocity = Vector3.zero;

        public ObjectFollowComponent(Transform main, PlayerTransform target, float smoothTime)
        {
            _smoothTime = smoothTime;
            _target = target;
            _main = main;

            if (_main != null && target != null)
                _offset = _main.position - _target.transform.position;
        }

        public void Tick()
        {
            Vector3 targetPosition = _target.transform.position + _offset;
            _main.position = Vector3.SmoothDamp(_main.position, targetPosition, ref _velocity, _smoothTime);
        }
    }
}