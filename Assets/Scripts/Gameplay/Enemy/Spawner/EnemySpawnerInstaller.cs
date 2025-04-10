using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Transform[] _patrolPoints;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemySpawner>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<IEnemySpawner>()
                .To<EnemyPool>()
                .FromResolve();

            Container
                .Bind<EnemyPatrolPointManager>()
                .AsSingle()
                .WithArguments(_patrolPoints)
                .NonLazy();

            Container
                .BindMemoryPool<Enemy, EnemyPool>()
                .FromComponentInNewPrefab(_enemyPrefab)
                .AsSingle()
                .Lazy();
        }
    }
}