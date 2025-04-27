using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyImpulseComponent : ITickable
    {
        private readonly Rigidbody _rigidbody;
        private float _impulseTime = 0.1f;
        private float _timer = 0;

        private bool _isPushable;
        private bool _isOnimpulse;

        public EnemyImpulseComponent(Rigidbody rigidbody, bool isPushable)
        {
            _rigidbody = rigidbody;
            _isPushable = isPushable;
        }

        public void SetImpulse()
        {
            _timer = _impulseTime;
        }

        public void Tick()
        {
            if (!_isPushable) return;

            if (_timer <= 0) return;

            _timer -= Time.deltaTime;
            if (_timer > 0)
            {
                if (_isOnimpulse == false)
                {
                    _isOnimpulse = true;
                    _rigidbody.isKinematic = false;
                    _rigidbody.AddForce(-_rigidbody.transform.forward * 50, ForceMode.Impulse);
                }
            }
            else
            {
                _isOnimpulse = false;
                _rigidbody.isKinematic = true;
            }
        }
    }
}