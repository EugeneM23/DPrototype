using UnityEngine;
using Zenject;

namespace Gameplay
{
    /*public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private HealthComponent _enemyPrefab;
        [SerializeField] private Transform[] _patrolPoints;
        [SerializeField] private bool _IsCyclebl;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemySpawner>()
                .AsSingle().WithArguments(_IsCyclebl)
                .NonLazy();

            Container
                .Bind<IEnemySpawner>()
                .To<EnemyPool>()
                .FromResolve();


            Container
                .BindMemoryPool<HealthComponent, EnemyPool>()
                .FromComponentInNewPrefab(_enemyPrefab)
                .AsSingle()
                .Lazy();

            Container
                .Bind<EnemyPatrolPointManager>()
                .AsSingle()
                .WithArguments(_patrolPoints)
                .NonLazy();
        }
    }*/
}