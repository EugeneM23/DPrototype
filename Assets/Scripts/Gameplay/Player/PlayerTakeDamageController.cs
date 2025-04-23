using Zenject;

namespace Gameplay
{
    public class PlayerTakeDamageController : IInitializable
    {
        private readonly HealthComponent _health;
        private PlayerHealthView _playerHealthView;
        private PlayEffectComponent _playEffectComponentSpawner;

        public PlayerTakeDamageController(HealthComponent health, PlayerHealthView playerHealthView,
            PlayEffectComponent playEffectComponentSpawner)
        {
            _health = health;
            _playerHealthView = playerHealthView;
            _playEffectComponentSpawner = playEffectComponentSpawner;
        }

        public void Initialize()
        {
            _health.OnHealthChanged += _playerHealthView.UpdateHealth;
            _health.OnHit += _playEffectComponentSpawner.Play;
        }
    }
}