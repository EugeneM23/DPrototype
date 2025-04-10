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
            var asd = Spawn();
            _manager.AddEnemy(asd.gameObject);
            return asd;
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