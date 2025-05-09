using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class WeaponSetings
    {
        [field: SerializeField] public float FireRate { get; private set; }
        [field: SerializeField] public float Scatter { get; private set; }
        [field: SerializeField] public float FireRange { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float BulletSpeed { get; private set; }
        [field: SerializeField] public float CameraShakeDuration { get; private set; }
        [field: SerializeField] public float CameraShakeMagnitude { get; private set; }
        [field: SerializeField] public Vector3 ShellImpulse { get; private set; }
        [field: SerializeField] public float ImpulsePower { get; private set; }
        [field: SerializeField] public int ProjectileCount { get; set; }
    }
}