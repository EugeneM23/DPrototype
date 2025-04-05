using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        private PlayerMoveComponent _playerMoveComponent;
        private PlayerRotationOnMoveComponent _playerRotationOnMoveComponent;
        private PlayerLookAtComponent _playerLookAtComponent;
        private CharacterController _characterController;
        private EnemyManager _enemyManager;

        public bool IsMoving => GetVelocity() != Vector3.zero;

        [Inject]
        private void Construct(PlayerMoveComponent moveComponent, PlayerRotationOnMoveComponent rotationComponent,
            PlayerLookAtComponent lookAtComponent, EnemyManager enemyManager)
        {
            _enemyManager = enemyManager;
            _playerMoveComponent = moveComponent;
            _playerRotationOnMoveComponent = rotationComponent;
            _playerLookAtComponent = lookAtComponent;
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (IsMoving) return;

            if (_enemyManager.TryGetTarget(_weapon.GetFireRange(), out GameObject target, this.transform))
            {
                LookAt(target.transform.position);

                if (HasLookedAt(target.transform.position))
                    _weapon.Shoot(target.transform);
            }
        }

        public bool HasLookedAt(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0f;

            if (direction == Vector3.zero)
                return true;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            float angle = Quaternion.Angle(transform.rotation, targetRotation);

            return angle < 1f;
        }

        public void Move(Vector3 direction)
        {
            _playerMoveComponent.Move(direction);
            _playerRotationOnMoveComponent.Ratation(direction);
        }

        public void LookAt(Vector3 position)
        {
            _playerLookAtComponent.LookAt(position);
        }

        public Vector3 GetVelocity()
        {
            return _characterController.velocity;
        }
    }
}