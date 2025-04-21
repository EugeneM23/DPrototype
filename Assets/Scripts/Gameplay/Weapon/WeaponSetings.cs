using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class WeaponSetings
    {
        [field: SerializeField] public float FireRate { get; private set; }
        [field: SerializeField] public float FireRange { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float BulletSpeed { get; private set; }
    }
}