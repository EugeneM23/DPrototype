using System;
using UnityEngine;

namespace Gameplay
{
    public interface IWeapon
    {
        public void Shoot();
        event Action OnFire;
    }
}