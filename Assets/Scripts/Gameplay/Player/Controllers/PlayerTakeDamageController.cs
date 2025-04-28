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
        private readonly DamageNumberSpawner _damageNumber;

        public PlayerTakeDamageController(HealthComponentBase playerHealth, PlayerHealtBar playerHealtBar,
            PlayEffectComponent playEffectComponentSpawner, DamageNumberSpawner damageNumber)
        {
            _playerHealth = playerHealth;
            _playerHealtBar = playerHealtBar;
            _playEffectComponentSpawner = playEffectComponentSpawner;
            _damageNumber = damageNumber;
        }

        public void Initialize()
        {
            _playerHealth.OnHealthChanged += _playerHealtBar.UpdatePlayerHealth;
            _playerHealth.OnHit += _playEffectComponentSpawner.Play;
            _playerHealth.OnTakeDamaged += _damageNumber.SpawnPopup;
        }
    }
}