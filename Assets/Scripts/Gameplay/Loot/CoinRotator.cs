using UnityEngine;

namespace Gameplay.Loot
{
    public class CoinRotator : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _rotationSpeed = 90f; // градусов в секунду
        [SerializeField] private float _bobFrequency = 2f; // колебания в секунду
        [SerializeField] private float _bobAmplitude = 0.25f; // амплитуда синусоиды
        private float _initialY;
        private float _time;

        public CoinRotator(Transform transform)
        {
            _transform = transform;
        }

        public void Update()
        {
            _transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime, Space.World);
        }
    }
}