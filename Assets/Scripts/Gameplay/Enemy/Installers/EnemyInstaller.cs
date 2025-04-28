using DamageNumbersPro;
using Game;
using Gameplay.Modules;
using Player;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private DamageNumber _popupPrefab;
        [SerializeField] private EnemySetings _enemySetings;
        [Inject] private readonly Transform _enemyTransform;
        [Inject] private readonly PlayerTransform _playerTransform;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Enemy>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IHealth>()
                .To<Health>()
                .AsSingle()
                .WithArguments(_enemySetings.Health)
                .NonLazy();

            Container
                .Bind<EnemyPatrolPointManager>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<EnemyAttackAssistComponent>()
                .AsSingle().WithArguments(_enemyTransform, _playerTransform.transform, _enemySetings.AttakRotationSpeed)
                .NonLazy();

            Container
                .Bind<DamageComponent>()
                .AsSingle()
                .WithArguments(_enemySetings.Damage)
                .NonLazy();


            EnemyHealthInstaller.Install(Container);
            EnemyStateInstaller.Install(Container, _enemySetings);
            EnemyAnimationInstaller.Install(Container);

            Container
                .BindInterfacesAndSelfTo<EnemyTakeDamageController>()
                .AsSingle()
                .NonLazy();

            Container.Bind<DamageNumberSpawner>().AsSingle().WithArguments(_popupPrefab, _enemyTransform).NonLazy();
        }
    }
}