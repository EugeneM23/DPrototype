using Game;
using Modules;
using UnityEngine;
using Zenject;

namespace DPrototype.Game
{
    public class CameraController : ILateTickable
    {
        private readonly ObjectFollowComponent _followComponent;
        private readonly CameraShakeComponent _shakeComponent;

        public CameraController(ObjectFollowComponent followComponent, CameraShakeComponent shakeComponent)
        {
            _followComponent = followComponent;
            _shakeComponent = shakeComponent;
        }

        public void LateTick() => _followComponent.Tick();

        public void SetTarget(Transform playerTransform)
        {
            _followComponent.SetTarget(playerTransform);
        }

        public void Shake(float shakeMagnitude, float shakeDuration)
        {
            _shakeComponent.CameraShake(shakeMagnitude, shakeDuration);
        }
    }
}