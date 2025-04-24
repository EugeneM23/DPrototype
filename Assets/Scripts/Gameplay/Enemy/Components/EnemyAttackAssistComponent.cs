using UnityEngine;

namespace Gameplay
{
    public class EnemyAttackAssistComponent
    {
        private readonly Transform _enemyTransform;
        private readonly Transform _target;
        private readonly float _rotationSpeed;

        public EnemyAttackAssistComponent(Transform enemyTransform, Transform target, float rotationSpeed)
        {
            _enemyTransform = enemyTransform;
            _target = target;
            _rotationSpeed = rotationSpeed;
        }

        public void RotateToTarget()
        {
            Vector3 direction = _target.position - _enemyTransform.position;

            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            _enemyTransform.rotation = Quaternion.Slerp(_enemyTransform.rotation, targetRotation,
                _rotationSpeed * Time.deltaTime);
        }
    }
}