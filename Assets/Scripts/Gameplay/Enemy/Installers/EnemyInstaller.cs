using Game;
using Gameplay.Modules;
using Player;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
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
                .AsSingle().WithArguments(_enemyTransform, _playerTransform.Transform, _enemySetings.AttakRotationSpeed)
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

            Container
                .BindInterfacesAndSelfTo<EnemyImpulseComponent>()
                .AsSingle().WithArguments(_enemySetings.IsPushable)
                .NonLazy();
        }
    }
}