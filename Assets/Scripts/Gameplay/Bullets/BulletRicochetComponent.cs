using System;
using UnityEngine;

namespace Gameplay
{
    internal class BulletRicochetComponent : MonoBehaviour
    {
        [SerializeField] private int _maxRicochets = 2;
        private int _currentRicochetCount;

        public bool CanRicochet => _currentRicochetCount < _maxRicochets;

        private void OnEnable()
        {
            _currentRicochetCount = 0;
        }

        public Vector3 CalculateRicochetDirection(Collision collision, Vector3 currentDirection)
        {
            _currentRicochetCount++;
            Vector3 newDirection = Vector3.Reflect(currentDirection, collision.contacts[0].normal).normalized;

            transform.forward = newDirection;

            return newDirection;
        }
    }
}