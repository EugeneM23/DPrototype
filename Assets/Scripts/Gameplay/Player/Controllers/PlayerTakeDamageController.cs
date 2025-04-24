using Gameplay.Common;
using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerTakeDamageController : IInitializable
    {
        private readonly HealthComponentBase _playerHealth;
        private HPBar _hpBar;
        private PlayEffectComponent _playEffectComponentSpawner;

        public PlayerTakeDamageController(HealthComponentBase playerHealth, HPBar hpBar,
            PlayEffectComponent playEffectComponentSpawner)
        {
            _playerHealth = playerHealth;
            _hpBar = hpBar;
            _playEffectComponentSpawner = playEffectComponentSpawner;
        }

        public void Initialize()
        {
            _playerHealth.OnHealthChanged += _hpBar.UpdatePlayerHealth;
            _playerHealth.OnHit += _playEffectComponentSpawner.Play;
        }
    }
}