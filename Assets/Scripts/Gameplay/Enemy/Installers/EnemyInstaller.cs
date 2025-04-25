using Gameplay;
using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemySetings _enemySetings;
        [Inject] private readonly Transform _enemyTransform;
        [Inject] private readonly Transform _playerTransform;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Enemy>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<EnemyPatrolPointManager>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<EnemyAttackAssistComponent>()
                .AsSingle().WithArguments(_enemyTransform, _playerTransform, _enemySetings.AttakRotationSpeed)
                .NonLazy();

            Container
                .Bind<EnemyDamageComponent>()
                .AsSingle()
                .WithArguments(_enemySetings.Damage)
                .NonLazy();


            EnemyHealthInstaller.Install(Container);
            EnemyStateInstaller.Install(Container, _enemySetings);
            EnemyAnimationInstaller.Install(Container);
        }
    }
}