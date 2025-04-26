using UnityEngine;
using Zenject;

namespace Game
{
    public class EnemyRangeAttackComponent : MonoBehaviour
    {
        [SerializeField] private ArcMover _projectilePrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _projectileSpeed = 10f;

        [Inject] private readonly PlayerTransform _playerTransform;

        public void Fire()
        {
            Vector3 targetPosition = CalculatePredictedPosition();
            ArcMover projectile = Instantiate(_projectilePrefab, _firePoint.position, Quaternion.identity);
            projectile.Construct(_firePoint.position, targetPosition);
        }

        private Vector3 CalculatePredictedPosition()
        {
            return _playerTransform.transform.position;
        }
    }
}