using Gameplay.Modules;
using NewEnemy;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private HealthComponentBase _enemyPrefab;
        [SerializeField] private bool IsCycle;
        [SerializeField] private float _spawnTime;

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
                .WithArguments(transform.position, IsCycle, _spawnTime)
                .NonLazy();
        }
    }
}