using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerTakeDamageController : IInitializable
    {
        private readonly HealthComponent _health;
        private HPBar _hpBar;
        private PlayEffectComponent _playEffectComponentSpawner;

        public PlayerTakeDamageController(HealthComponent health, HPBar hpBar,
            PlayEffectComponent playEffectComponentSpawner)
        {
            _health = health;
            _hpBar = hpBar;
            _playEffectComponentSpawner = playEffectComponentSpawner;
        }

        public void Initialize()
        {
            _health.OnHealthChanged += _hpBar.UpdateHealth;
            _health.OnHit += _playEffectComponentSpawner.Play;
        }
    }
}