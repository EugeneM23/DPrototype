using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class Player : MonoBehaviour
    {
        private PlayerMoveComponent playerMoveComponent;
        private RotationComponent _rotationComponent;
        private PlayerLookAtComponent playerLookAtComponent;
        private Weapon _weapon;

        [Inject]
        private void Construct(PlayerMoveComponent playerMoveComponent, RotationComponent rotationComponent, PlayerLookAtComponent playerLookAtComponent)
        {
            this.playerMoveComponent = playerMoveComponent;
            _rotationComponent = rotationComponent;
            this.playerLookAtComponent = playerLookAtComponent;
        }

        public void Move(Vector3 direction)
        {
            playerMoveComponent.Move(direction);
            _rotationComponent.Ratation(direction);
        }

        public void LookAt(Vector3 position)
        {
            playerLookAtComponent.LookAt(position);
        }

        public void Shoot(Transform targer)
        {
            //_weapon.Shoot(targer);
        }
    }

    internal class Weapon : IWeapon
    {
        public void Shoot(Transform targer)
        {
            
        }
    }

    internal interface IWeapon
    {
        public void Shoot(Transform targer);
    }
}