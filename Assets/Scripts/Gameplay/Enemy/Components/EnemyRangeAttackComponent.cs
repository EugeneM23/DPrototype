using Game;
using UnityEngine;
using Zenject;

namespace Game
{
    public class EnemyRangeAttackComponent : MonoBehaviour
    {
        [SerializeField] private ParabolaShoot _projectilePrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _projectileSpeed = 10f; // Скорость снаряда

        [Inject] private readonly PlayerTransform _playerTransform;

        public void Fire()
        {
            Vector3 targetPosition = CalculatePredictedPosition();
            ParabolaShoot projectile = Instantiate(_projectilePrefab, _firePoint.position, Quaternion.identity);
            projectile.Construct(_firePoint.position, targetPosition);
        }

        private Vector3 CalculatePredictedPosition()
        {
            return _playerTransform.transform.position;
            Vector3 playerPosition = _playerTransform.transform.position;
            Vector3 playerVelocity = _playerTransform.GetVelocity();

            Vector3 toPlayer = playerPosition - _firePoint.position;
            float distance = toPlayer.magnitude;

            float timeToReachTarget = distance / _projectileSpeed;

            Vector3 predictedPosition = playerPosition + playerVelocity * timeToReachTarget;

            return predictedPosition;
        }
    }
}