using Gameplay;
using UnityEngine;
using Zenject;

namespace NewEnemy
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private EnemyHealthComponent _enemyPrefab;

        public override void InstallBindings()
        {
            Container
                .BindMemoryPool<EnemyHealthComponent, EnemyPool>()
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