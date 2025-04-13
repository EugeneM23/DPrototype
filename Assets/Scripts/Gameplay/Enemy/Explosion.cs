using System;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnEnable()
    {
        _particleSystem.Stop();
    }

    public void Explode()
    {
        _particleSystem.Play();
    }
}