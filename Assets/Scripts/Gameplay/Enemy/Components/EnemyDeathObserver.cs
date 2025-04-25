using Gameplay.Modules;
using Zenject;

namespace Gameplay
{
    public class EnemyDeathObserver : IInitializable
    {
        private readonly EnemyStateManager _stateManager;
        private readonly HealthComponentBase _enemyHealthComponent;

        public EnemyDeathObserver(EnemyStateManager stateManager, HealthComponentBase enemyHealthComponent)
        {
            _stateManager = stateManager;
            _enemyHealthComponent = enemyHealthComponent;
        }

        public void Initialize()
        {
            _enemyHealthComponent.OnDespawn += Despawn;
        }

        private void Despawn(HealthComponentBase obj)
        {
            _stateManager.IsBusy = false;
        }
    }
}