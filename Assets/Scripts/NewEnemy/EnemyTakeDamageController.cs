using Gameplay;
using Modules;
using Zenject;

namespace NewEnemy
{
    public class EnemyTakeDamageController : IInitializable
    {
        private readonly HealthComponent _health;
        private HPBar _hpBar;

        public EnemyTakeDamageController(HealthComponent health, HPBar hpBar)
        {
            _health = health;
            _hpBar = hpBar;
        }

        public void Initialize()
        {
            _health.OnHealthChanged += _hpBar.UpdateHealth;
        }
    }
}