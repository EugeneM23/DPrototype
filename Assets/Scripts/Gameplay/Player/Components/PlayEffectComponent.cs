using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayEffectComponent
    {
        private ParticleSystem _particleSystem;

        public PlayEffectComponent(ParticleSystem particleSystem) => _particleSystem = particleSystem;

        public void Play() => _particleSystem.Play();
    }
}