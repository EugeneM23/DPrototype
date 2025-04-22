using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerHitEffect
    {
        [Inject] private ParticleSystem _particleSystem;

        public void Hit() => _particleSystem.Play();
    }
}