using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private Animator _animator;

        private PlayerMove _playerMove;
        private PlayerRotationOnMove _playerRotor;
        private PlayerLookAt _lookAt;
        private CharacterController _characterController;
        private GameObject _target;

        private bool IsMoving => GetVelocity() != Vector3.zero;
        public Animator Animator => _animator;

        [Inject]
        private void Construct(PlayerMove move, PlayerRotationOnMove rotation, PlayerLookAt lookAt)
        {
            _playerMove = move;
            _playerRotor = rotation;
            _lookAt = lookAt;
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (IsMoving || _target == null) return;

            if (_lookAt.LookAtAndCheck(_target.transform.position))
                _weapon.Shoot(_target.transform);
        }

        public void Move(Vector3 direction)
        {
            _playerMove.Move(direction);
            _playerRotor.Ratation(direction);
        }

        public void SetTarget(GameObject target) => _target = target;
        public Vector3 GetVelocity() => _characterController.velocity;

        public Weapon GetWeapon() => _weapon;
    }
}