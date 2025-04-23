using UnityEngine;
using Zenject;

namespace NewEnemy
{
    public class EnemySpawner : IInitializable, ITickable
    {
        private IEnemySpawner _spawner;
        private Vector3 _spawnPosition;
        private float _spawnTime = 3;

        public EnemySpawner(IEnemySpawner spawner, Vector3 spawnPosition)
        {
            _spawner = spawner;
            _spawnPosition = spawnPosition;
        }

        public void Initialize()
        {
            _spawner.Create(_spawnPosition);
        }

        public void Tick()
        {
            _spawnTime -= Time.deltaTime;
            if (_spawnTime <= 0)
            {
                _spawner.Create(_spawnPosition);
                _spawnTime = 3;
            }
        }
    }
}