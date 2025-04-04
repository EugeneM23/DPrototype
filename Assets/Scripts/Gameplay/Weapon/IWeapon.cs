using UnityEngine;

namespace Gameplay.Weapon
{
    internal interface IWeapon
    {
        public void Shoot(Transform targer);
    }
}