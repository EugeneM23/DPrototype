using Gameplay;
using Modules;
using UnityEngine;
using Zenject;

namespace NewEnemy
{
    public class EnemyPool : MemoryPool<Vector3, EnemyHealthComponent>, IEnemySpawner
    {
        private readonly EnemyManager _manager;

        public EnemyPool(EnemyManager manager)
        {
            _manager = manager;
        }

        public EnemyHealthComponent Create(Vector3 position)
        {
            return Spawn(position);
        }

        protected override void Reinitialize(Vector3 position, EnemyHealthComponent enemy)
        {
            enemy.gameObject.transform.position = position;
        }

        protected override void OnSpawned(EnemyHealthComponent enemy)
        {
            base.OnSpawned(enemy);
            enemy.gameObject.SetActive(true);
            enemy.OnDespawn += Despawn;
            enemy.Reset();
            
            _manager.AddEnemy(enemy);
        }

        protected override void OnDespawned(EnemyHealthComponent enemy)
        {
            base.OnDespawned(enemy);
            enemy.gameObject.SetActive(false);
            enemy.OnDespawn -= Despawn;
            _manager.RemoveEnemy(enemy);
        }
    }

    public interface IEnemySpawner
    {
        public EnemyHealthComponent Create(Vector3 position);
    }
}