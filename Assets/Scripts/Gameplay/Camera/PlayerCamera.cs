using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerCamera : ILateTickable
    {
        private readonly ObjectFollowComponent _followComponent;

        public PlayerCamera(ObjectFollowComponent followComponent)
        {
            _followComponent = followComponent;
        }

        public void LateTick() => _followComponent.Tick();
    }
}