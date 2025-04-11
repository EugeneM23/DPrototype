using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private Animator _animator;

        private PlayerMoveComponent _playerMoveComponent;
        private PlayerRotationOnMoveComponent _playerRotor;
        private PlayerLookAtComponent _lookAtComponent;
        private CharacterController _characterController;
        private GameObject _target;
        private Transform _playerTransform => gameObject.transform;

        private bool IsMoving => GetVelocity() != Vector3.zero;
        public Animator Animator => _animator;

        [Inject]
        private void Construct(PlayerMoveComponent moveComponent, PlayerRotationOnMoveComponent rotation,
            PlayerLookAtComponent lookAtComponent)
        {
            _playerMoveComponent = moveComponent;
            _playerRotor = rotation;
            _lookAtComponent = lookAtComponent;
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (IsMoving || _target == null) return;

            if (_lookAtComponent.LookAtAndCheck(_target.transform.position))
            {
                _weapon.Shoot(_target.transform);
            }
        }

        public void Move(Vector3 direction)
        {
            _playerMoveComponent.Move(direction);
            _playerRotor.Ratation(direction);
        }

        public void SetTarget(GameObject target) => _target = target;
        public Vector3 GetVelocity() => _characterController.velocity;

        public Weapon GetWeapon() => _weapon;

        public Transform GetTransform() => _playerTransform;
    }
}