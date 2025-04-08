using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemySpawner : IInitializable
    {
        private readonly Transform _enemyTransfrom;
        private readonly EnemyManager _manager;

        public EnemySpawner(EnemyManager manager, Transform enemyTransfrom)
        {
            _manager = manager;
            _enemyTransfrom = enemyTransfrom;
        }

        public void Initialize()
        {
            //GameObject enemy = _manager.SpawnEnemy(_enemyTransfrom.gameObject, Vector3.zero);
        }
    }
}