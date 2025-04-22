using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Player : ITickable
    {
        private readonly PlayerTransform _playerTransform;
        private readonly Animator _animator;
        private readonly PlayerHealthComponent _playerHealth;
        private readonly CharacterController _characterController;

        private readonly PlayerMoveComponent _playerMoveComponent;
        private readonly PlayerRotationOnMoveComponent _playerRotor;
        private readonly PlayerLookAtComponent _lookAtComponent;

        private Weapon _weapon;

        private GameObject _target;

        private bool IsMoving => GetVelocity() != Vector3.zero;
        public Animator Animator => _animator;

        public Player(PlayerTransform playerTransform, Animator animator, PlayerHealthComponent playerHealth,
            CharacterController characterController, PlayerMoveComponent playerMoveComponent,
            PlayerRotationOnMoveComponent playerRotor, PlayerLookAtComponent lookAtComponent)
        {
            _playerTransform = playerTransform;
            _animator = animator;
            _playerHealth = playerHealth;
            _characterController = characterController;
            _playerMoveComponent = playerMoveComponent;
            _playerRotor = playerRotor;
            _lookAtComponent = lookAtComponent;
        }

        public void Tick()
        {
            if (IsMoving || _target == null) return;

            if (_lookAtComponent.LookAtAndCheck(_target.transform.position))
                _weapon.Shoot();
        }

        public void Move(Vector3 direction)
        {
            _playerMoveComponent.Move(direction);
            _playerRotor.Ratation(direction);
        }

        public void SetTarget(GameObject target) => _target = target;

        public Vector3 GetVelocity() => _characterController.velocity;

        public void SetWeapon(Weapon weapon) => _weapon = weapon;

        public void TakeDamage(int damageDamage)
        {
            _playerHealth.TakeDamage(damageDamage);
        }
    }
}