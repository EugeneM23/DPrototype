using Modules;
using Zenject;

namespace Gameplay
{
    public abstract class DeathObserver : IInitializable
    {
        private readonly HealthComponent _health;
        public DeathObserver(HealthComponent health) => _health = health;

        public void Initialize() => _health.OnDeath += Death;


        public abstract void Death(HealthComponent obj);
    }
}