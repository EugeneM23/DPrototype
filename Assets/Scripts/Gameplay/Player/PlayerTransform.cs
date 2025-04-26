using System;
using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayerTransform : MonoBehaviour
    {
        [Inject] private CharacterController _character;
        private float _timer;
        private Vector3 originPosition;
        public Vector3 Velocity;
        public Transform Transform => gameObject.transform;

        public Vector3 GetVelocity() => _character.velocity;
        
        
    }
}