using Gameplay.Modules;
using UnityEngine;
using Zenject;

namespace NewEnemy
{
    public class EnemyPool : MemoryPool<Vector3, HealthComponentBase>, IEnemySpawner
    {
        public HealthComponentBase Create(Vector3 position)
        {
            return Spawn(position);
        }

        protected override void Reinitialize(Vector3 position, HealthComponentBase enemy)
        {
            enemy.gameObject.transform.position = position;
        }

        protected override void OnSpawned(HealthComponentBase enemy)
        {
            base.OnSpawned(enemy);
            enemy.gameObject.SetActive(true);
            enemy.OnDespawn += Despawn;
            enemy.Reset();
            
        }

        protected override void OnDespawned(HealthComponentBase enemy)
        {
            base.OnDespawned(enemy);
            enemy.gameObject.SetActive(false);
            enemy.OnDespawn -= Despawn;
        }
    }

    public interface IEnemySpawner
    {
        public HealthComponentBase Create(Vector3 position);
    }
}