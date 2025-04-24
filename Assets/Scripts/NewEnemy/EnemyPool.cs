using Gameplay;
using Modules;
using UnityEngine;
using Zenject;

namespace NewEnemy
{
    public class EnemyPool : MemoryPool<Vector3, HealthComponent>, IEnemySpawner
    {
        private readonly EnemyManager _manager;

        public EnemyPool(EnemyManager manager)
        {
            _manager = manager;
        }

        public HealthComponent Create(Vector3 position)
        {
            return Spawn(position);
        }

        protected override void Reinitialize(Vector3 position, HealthComponent enemy)
        {
            enemy.gameObject.transform.position = position;
        }

        protected override void OnSpawned(HealthComponent enemy)
        {
            base.OnSpawned(enemy);
            enemy.gameObject.SetActive(true);
            enemy.OnDeath += Despawn;
            enemy.Reset();
            
            _manager.AddEnemy(enemy);
        }

        protected override void OnDespawned(HealthComponent enemy)
        {
            base.OnDespawned(enemy);
            enemy.gameObject.SetActive(false);
            enemy.OnDeath -= Despawn;
            _manager.RemoveEnemy(enemy);
        }
    }

    public interface IEnemySpawner
    {
        public HealthComponent Create(Vector3 position);
    }
}