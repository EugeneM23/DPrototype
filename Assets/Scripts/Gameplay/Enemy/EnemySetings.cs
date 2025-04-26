using System;
using UnityEngine;

[Serializable]
public class EnemySetings
{
    [field: SerializeField] public float ChaseRange { get; private set; }
    [field: SerializeField] public float AttckRange { get; private set; }
    [field: SerializeField] public float CahaseSpeed { get; private set; }
    [field: SerializeField] public float PatrolSpeed { get; private set; }
    [field: SerializeField] public float AttakRotationSpeed { get; set; }
    [field: SerializeField] public int Damage { get; set; }
    [field: SerializeField] public string[] AttckAnimations { get; set; }
}