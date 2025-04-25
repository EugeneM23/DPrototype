using Gameplay;
using Gameplay.Modules;
using UnityEngine;
using Zenject;

namespace NewEnemy
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private HealthComponentBase _enemyPrefab;

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
                .WithArguments(transform.position)
                .NonLazy();
        }
    }
}