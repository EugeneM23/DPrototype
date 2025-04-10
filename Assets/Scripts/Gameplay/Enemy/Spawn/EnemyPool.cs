using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyPool : MemoryPool<Vector3, Enemy>, IEnemySpawner
    {
        private EnemyManager _manager;

        public EnemyPool(EnemyManager manager)
        {
            _manager = manager;
        }

        protected override void Reinitialize(Vector3 p1, Enemy enemy)
        {
            enemy.SetPosition(p1);
        }

        public Enemy Create(Vector3 position)
        {
            Enemy enemy = Spawn(position);
            return enemy;
        }

        protected override void OnSpawned(Enemy enemy)
        {
            base.OnSpawned(enemy);
            _manager.AddEnemy(enemy.gameObject);
            enemy.gameObject.SetActive(true);
            enemy.DeSpawn += this.Despawn;
        }

        protected override void OnDespawned(Enemy enemy)
        {
            base.OnDespawned(enemy);
            enemy.gameObject.SetActive(false);
            _manager.RemoveEnemy(enemy.gameObject);
            enemy.DeSpawn -= this.Despawn;
        }
    }
}