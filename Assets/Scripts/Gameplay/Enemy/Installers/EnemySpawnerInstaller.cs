using Modules;
using UnityEngine;
using Zenject;

namespace NewEnemy
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private HealthComponent _enemyPrefab;

        public override void InstallBindings()
        {
            Container
                .BindMemoryPool<HealthComponent, EnemyPool>()
                .FromComponentInNewPrefab(_enemyPrefab);

            Container
                .Bind<IEnemySpawner>()
                .To<EnemyPool>()
                .FromResolve();

            Container
                .BindInterfacesAndSelfTo<EnemySpawner>()
                .AsSingle()
                .WithArguments(transform.position)
                .NonLazy();
        }
    }
}