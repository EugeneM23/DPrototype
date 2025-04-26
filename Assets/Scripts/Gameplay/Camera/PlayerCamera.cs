using Game;
using Modules;
using UnityEngine;
using Zenject;

namespace DPrototype.Game
{
    public class PlayerCamera : ILateTickable
    {
        private readonly ObjectFollowComponent _followComponent;
        private readonly CameraShakeComponent _shakeComponent;

        public PlayerCamera(ObjectFollowComponent followComponent, CameraShakeComponent shakeComponent)
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
            _shakeComponent.CameraShake(0.3f, 0.1f);
        }
    }
}