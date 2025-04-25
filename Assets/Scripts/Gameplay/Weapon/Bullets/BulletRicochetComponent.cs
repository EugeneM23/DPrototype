using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletRicochetComponent
    {
        private readonly int _maxRicochets;
        private readonly Transform _transform;

        private int _currentRicochetCount = 0;

        public bool CanRicochet => _currentRicochetCount < _maxRicochets;

        public BulletRicochetComponent(int maxRicochets, Transform transform)
        {
            _maxRicochets = maxRicochets;
            _transform = transform;
        }

        public void Reset() => _currentRicochetCount = 0;

        public Vector3 Ricochet(Collision collision)
        {
            Vector3 newDirection = Vector3.Reflect(_transform.forward, collision.contacts[0].normal).normalized;
            _transform.forward = newDirection;

            _currentRicochetCount++;

            return newDirection;
        }
    }
}