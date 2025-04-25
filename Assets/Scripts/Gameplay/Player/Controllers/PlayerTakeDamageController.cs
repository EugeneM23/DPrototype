using Gameplay.Modules;
using Modules;
using Player;
using Zenject;

namespace Game
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