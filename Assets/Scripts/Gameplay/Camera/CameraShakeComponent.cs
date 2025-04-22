using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class CameraShakeComponent : ITickable, IInitializable
    {
        private readonly Transform _camera;
        private float _shakeMagnitude = 0.1f;
        private float _shakeDuration = 0.2f;

        private Quaternion _originalRotation;
        private bool _isReturning;

        public CameraShakeComponent(Transform camera)
        {
            _camera = camera;
        }

        public void Initialize()
        {
            _originalRotation = _camera.localRotation;
        }

        public void CameraShake(float shakeMagnitude, float shakeDuration)
        {
            _shakeDuration = shakeDuration;
            _shakeMagnitude = shakeMagnitude;
        }

        public void Tick()
        {
            if (_shakeDuration > 0)
            {
                float angleX = Random.Range(-1f, 1f) * _shakeMagnitude;
                float angleY = Random.Range(-1f, 1f) * _shakeMagnitude;
                float angleZ = Random.Range(-1f, 1f) * _shakeMagnitude;

                Quaternion shakeRotation = Quaternion.Euler(angleX, angleY, angleZ);

                _camera.localRotation = _originalRotation * shakeRotation;

                _shakeDuration -= Time.deltaTime;

                if (_shakeDuration <= 0f)
                {
                    _isReturning = true;
                }
            }
            else if (_isReturning)
            {
                // Плавное возвращение к оригинальному повороту
                _camera.localRotation = Quaternion.Lerp(_camera.localRotation,
                    _originalRotation, Time.deltaTime * 0.3f);

                // Когда достаточно близко — зафиксировать
                if (Quaternion.Angle(_camera.localRotation, _originalRotation) < 0.01f)
                {
                    _camera.localRotation = _originalRotation;
                    _isReturning = false;
                }
            }
        }
    }
}