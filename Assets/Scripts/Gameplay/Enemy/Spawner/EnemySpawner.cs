using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemySpawner : IInitializable, ITickable
    {
        private readonly Transform _spawnerTransform;
        private readonly IEnemySpawner _spawner;
        private float _spwnTime = 1;

        public EnemySpawner(IEnemySpawner spawner, Transform spawnerTransform)
        {
            _spawner = spawner;
            _spawnerTransform = spawnerTransform;
        }

        public void Initialize()
        {
            _spawner.Create(_spawnerTransform.position);
        }

        public void Tick()
        {
            /*_spwnTime -= Time.deltaTime;

            if (_spwnTime <= 0)
            {
                _spawner.Create(_spawnerTransform.position);
                _spwnTime = 1;
            }*/
        }
    }
}