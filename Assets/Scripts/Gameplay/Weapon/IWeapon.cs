using UnityEngine;

namespace Gameplay.Player
{
    internal interface IWeapon
    {
        public void Shoot(Transform targer);
    }
}