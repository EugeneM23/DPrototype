using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyDeathObserver : IInitializable
    {
        private readonly EnemyStateObserver _stateObserver;
        private readonly EnemyHealthComponent _enemyHealthComponent;

        public EnemyDeathObserver(EnemyStateObserver stateObserver, EnemyHealthComponent enemyHealthComponent)
        {
            _stateObserver = stateObserver;
            _enemyHealthComponent = enemyHealthComponent;
        }

        public void Initialize()
        {
            _enemyHealthComponent.OnDespawn += Despawn;
        }

        private void Despawn(EnemyHealthComponent obj)
        {
            Debug.Log("Death");
            _stateObserver.IsBusy = false;
        }
    }
}