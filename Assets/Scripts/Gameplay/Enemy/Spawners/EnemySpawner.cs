using NewEnemy;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemySpawner : IInitializable, ITickable
    {
        private IEnemySpawner _spawner;
        private Vector3 _spawnPosition;

        private float _spawnTime;
        private bool IsCycle;
        private int _startCount;

        public EnemySpawner(IEnemySpawner spawner, Vector3 spawnPosition, bool isCycle, float spawnTime, int startCount)
        {
            _spawner = spawner;
            _spawnPosition = spawnPosition;
            IsCycle = isCycle;
            _spawnTime = spawnTime;
            _startCount = startCount;
        }

        public void Initialize()
        {
            for (int i = 0; i < _startCount; i++) 
                _spawner.Create(_spawnPosition);
        }

        public void Tick()
        {
            if (IsCycle)
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
}