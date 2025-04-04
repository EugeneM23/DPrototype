using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class PlayerParameters
    {
        [field: SerializeField] public float Speed { get; private set; }
        
        [field: SerializeField] public int AimingDistance { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float AimingSpeed { get; private set; }
    }
}