using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    /*public class EnemySpawner : IInitializable, ITickable
    {
        private readonly Transform _spawnerTransform;
        private readonly IEnemySpawner _spawner;
        private float _spwnTime = 1;

        private readonly bool _isCyclebl;

        public EnemySpawner(IEnemySpawner spawner, Transform spawnerTransform, bool isCyclebl)
        {
            _spawner = spawner;
            _spawnerTransform = spawnerTransform;
            _isCyclebl = isCyclebl;
        }

        public void Initialize()
        {
            for (int i = 0; i < 1; i++)
            {
                _spawner.Create(_spawnerTransform.position);
            }
        }

        public void Tick()
        {
            if (!_isCyclebl) return;

            _spwnTime -= Time.deltaTime;

            if (_spwnTime <= 0)
            {
                _spawner.Create(_spawnerTransform.position);
                _spwnTime = 1;
            }
        }
    }*/
}