using Zenject;

namespace Gameplay
{
    public class PlayerTakeDamageController : IInitializable
    {
        private readonly PlayerHealthComponent _playerHealth;
        private PlayerHealthView _playerHealthView;
        private PlayerHitEffect _playerHitEffectSpawner;

        public PlayerTakeDamageController(PlayerHealthComponent playerHealth, PlayerHealthView playerHealthView,
            PlayerHitEffect playerHitEffectSpawner)
        {
            _playerHealth = playerHealth;
            _playerHealthView = playerHealthView;
            _playerHitEffectSpawner = playerHitEffectSpawner;
        }

        public void Initialize()
        {
            _playerHealth.OnHealthChanged += _playerHealthView.UpdateHealth;
            _playerHealth.OnHit += _playerHitEffectSpawner.Hit;
        }
    }
}