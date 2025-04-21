using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CameraShakeComponent : ITickable, IInitializable
    {
        private float _shakeMagnitude = 0.1f;
        private float _shakeDuration = 0.2f;

        private Quaternion _originalRotation;
        private bool _isReturning;

        public void Initialize() => _originalRotation = Camera.main.transform.localRotation;

        public void CameraShake()
        {
            Debug.Log("CameraShake");
            _shakeDuration = 0.1f;
            _shakeMagnitude = 0.2f;
        }

        public void Tick()
        {
            if (_shakeDuration > 0)
            {
                float angleX = Random.Range(-1f, 1f) * _shakeMagnitude;
                float angleY = Random.Range(-1f, 1f) * _shakeMagnitude;
                float angleZ = Random.Range(-1f, 1f) * _shakeMagnitude;

                Quaternion shakeRotation = Quaternion.Euler(angleX, angleY, angleZ);

                Camera.main.transform.localRotation = _originalRotation * shakeRotation;

                _shakeDuration -= Time.deltaTime;

                if (_shakeDuration <= 0f)
                {
                    _isReturning = true;
                }
            }
            else if (_isReturning)
            {
                // Плавное возвращение к оригинальному повороту
                Camera.main.transform.localRotation = Quaternion.Lerp(Camera.main.transform.localRotation,
                    _originalRotation, Time.deltaTime * 0.3f);

                // Когда достаточно близко — зафиксировать
                if (Quaternion.Angle(Camera.main.transform.localRotation, _originalRotation) < 0.01f)
                {
                    Camera.main.transform.localRotation = _originalRotation;
                    _isReturning = false;
                }
            }
        }
    }
}