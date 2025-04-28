using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    internal class PushableObject : MonoBehaviour
    {
        [Inject] private Rigidbody _rigidbody;

        private float _timer;
        private bool _isOnimpulse;
        private Vector3 _direction;
        private float _impulsPower;

        private void OnEnable()
        {
            _timer = 0;
            _rigidbody.isKinematic = true;
        }

        private void Update()
        {
            if (_timer <= 0) return;

            _timer -= Time.deltaTime;
            if (_timer > 0)
            {
                if (_isOnimpulse == false)
                {
                    _isOnimpulse = true;
                    _rigidbody.isKinematic = false;
                    _rigidbody.AddForce(_direction * _impulsPower, ForceMode.Impulse);
                }
            }
            else
            {
                _isOnimpulse = false;
                _rigidbody.isKinematic = true;
            }
        }

        public void SetImpulse(Vector3 direction, float impulsPower, float impulstime)
        {
            _direction = direction;
            _impulsPower = impulsPower;
            _timer = impulstime;
        }
    }
}