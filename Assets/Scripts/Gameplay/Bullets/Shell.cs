using System;
using System.Collections;
using UnityEngine;

namespace Gameplay
{
    public class Shell : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _impuls;

        public event Action<Shell> OnDispose;
        private readonly int _lifeTime = 2;

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        private void OnEnable() => StartCoroutine(LifeRoutine());

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSeconds(_lifeTime);
            OnDispose?.Invoke(this);
        }

        public void SetVelocity(Vector3 direction)
        {
            _rb.AddForce((direction + Vector3.up) * _impuls, ForceMode.Impulse);
            _rb.AddTorque(direction * 40, ForceMode.Impulse);
        }
    }
}