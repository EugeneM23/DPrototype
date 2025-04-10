using Zenject;

namespace Gameplay
{
    public class EnemyPool : MemoryPool<Enemy>, IEnemySpawner
    {
        private EnemyManager _manager;

        public EnemyPool(EnemyManager manager)
        {
            _manager = manager;
        }

        public Enemy Create()
        {
            Enemy enemy = Spawn();
            _manager.AddEnemy(enemy.gameObject);
            return enemy;
        }

        protected override void OnSpawned(Enemy enemy)
        {
            base.OnSpawned(enemy);
            enemy.DeSpawn += this.Despawn;
        }

        protected override void OnDespawned(Enemy enemy)
        {
            base.OnDespawned(enemy);
            enemy.DeSpawn += this.Despawn;
        }
    }
}