using Modules;
using Zenject;

namespace DPrototype.Game
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