using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemySpawner : IInitializable
    {
        private readonly IEnemySpawner _spawner;

        public EnemySpawner(IEnemySpawner spawner)
        {
            _spawner = spawner;
        }

        public void Initialize()
        {
            _spawner.Create();
        }
    }
}