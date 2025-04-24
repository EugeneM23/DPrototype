using Gameplay;
using Modules;
using Zenject;

namespace NewEnemy
{
    public class EnemyTakeDamageController : IInitializable
    {
        private readonly HealthComponent _health;

        public EnemyTakeDamageController(HealthComponent health)
        {
            _health = health;
        }

        public void Initialize()
        {
        }
    }
}