using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Weapon.Weapon _weapon;

        private PlayerMoveComponent _playerMoveComponent;
        private PlayerRotationOnMoveComponent _playerRotationOnMoveComponent;
        private PlayerLookAtComponent _playerLookAtComponent;

        [Inject]
        private void Construct(PlayerMoveComponent moveComponent, PlayerRotationOnMoveComponent rotationComponent,
            PlayerLookAtComponent lookAtComponent)
        {
            _playerMoveComponent = moveComponent;
            _playerRotationOnMoveComponent = rotationComponent;
            _playerLookAtComponent = lookAtComponent;
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

        public void Shoot(Transform targer)
        {
            _weapon.Shoot(targer);
        }
    }
}