using System;
using Modules;
using UnityEngine;
using Zenject;

namespace Game
{
    public class Player : ITickable
    {
        public event Action OnShoot;

        private readonly CharacterController _characterController;
        private readonly MoveComponent _moveComponent;
        private readonly RotationComponent _rotationComponent;
        private readonly LookAtComponent _lookAtComponent;
        private readonly LeanComponent _leanComponent;

        private Transform _target;

        public bool IsMoving => GetVelocity() != Vector3.zero;

        public Player(CharacterController characterController, MoveComponent moveComponent,
            RotationComponent rotationComponent, LookAtComponent lookAtComponent, LeanComponent leanComponent)
        {
            _characterController = characterController;
            _moveComponent = moveComponent;
            _rotationComponent = rotationComponent;
            _lookAtComponent = lookAtComponent;
            _leanComponent = leanComponent;
        }

        public void Tick()
        {
            _leanComponent.Lean();

            if (IsMoving || _target == null) return;

            if (_lookAtComponent.LookAtAndCheck(_target.position))
                OnShoot?.Invoke();
        }

        public void Move(Vector3 direction)
        {
            _moveComponent.Move(direction);
            _rotationComponent.Ratation(direction);
        }

        public void SetTarget(Transform target) => _target = target;

        public Vector3 GetVelocity() => _characterController.velocity;
    }
}