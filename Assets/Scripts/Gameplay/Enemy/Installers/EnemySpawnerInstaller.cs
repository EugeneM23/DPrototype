using Gameplay.Modules;
using NewEnemy;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private HealthComponentBase _enemyPrefab;
        [SerializeField] private bool _isCycle;
        [SerializeField] private float _spawnTime;
        [SerializeField] private int _startCount;

        public override void InstallBindings()
        {
            Container
                .BindMemoryPool<HealthComponentBase, EnemyPool>()
                .FromComponentInNewPrefab(_enemyPrefab);

            Container
                .Bind<IEnemySpawner>()
                .To<EnemyPool>()
                .FromResolve();

            Container
                .BindInterfacesAndSelfTo<EnemySpawner>()
                .AsSingle()
                .WithArguments(transform.position, _isCycle, _spawnTime, _startCount)
                .NonLazy();
        }
    }
}