using Gameplay.Modules;
using Modules;
using Zenject;

namespace Gameplay
{
    public class PlayerTakeDamageController : IInitializable
    {
        private readonly HealthComponentBase _playerHealth;
        private PlayerHealtBar _playerHealtBar;
        private PlayEffectComponent _playEffectComponentSpawner;

        public PlayerTakeDamageController(HealthComponentBase playerHealth, PlayerHealtBar playerHealtBar,
            PlayEffectComponent playEffectComponentSpawner)
        {
            _playerHealth = playerHealth;
            _playerHealtBar = playerHealtBar;
            _playEffectComponentSpawner = playEffectComponentSpawner;
        }

        public void Initialize()
        {
            _playerHealth.OnHealthChanged += _playerHealtBar.UpdatePlayerHealth;
            _playerHealth.OnHit += _playEffectComponentSpawner.Play;
        }
    }
}