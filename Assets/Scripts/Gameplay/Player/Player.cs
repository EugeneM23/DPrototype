using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Player : ITickable
    {
        private readonly CharacterController _characterController;

        private readonly MoveComponent _moveComponent;
        private readonly RotationComponent _rotationComponent;
        private readonly LookAtComponent _lookAtComponent;
        //private readonly LeanComponent _leanComponent;

        private Weapon _weapon;
        private HealthComponent _target;

        private bool IsMoving => GetVelocity() != Vector3.zero;

        public Player(CharacterController characterController, MoveComponent moveComponent,
            RotationComponent rotationComponent, LookAtComponent lookAtComponent)
        {
            _characterController = characterController;
            _moveComponent = moveComponent;
            _rotationComponent = rotationComponent;
            _lookAtComponent = lookAtComponent;
            //_leanComponent = leanComponent;
        }

        public void Tick()
        {
            //_leanComponent.Lean();

            if (IsMoving || _target == null) return;

            if (_lookAtComponent.LookAtAndCheck(_target.transform.position))
                _weapon.Shoot();
        }

        public void Move(Vector3 direction)
        {
            _moveComponent.Move(direction);
            _rotationComponent.Ratation(direction);
        }

        public void SetWeapon(Weapon weapon) => _weapon = weapon;
        public void SetTarget(HealthComponent target) => _target = target;
        public Vector3 GetVelocity() => _characterController.velocity;
    }
}