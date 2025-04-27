using Gameplay;
using Zenject;

namespace Gameplay
{
    public class EnemyStateInstaller : Installer<EnemySetings, EnemyStateInstaller>
    {
        [Inject] private EnemySetings _setings;

        public override void InstallBindings()
        {
            Container
                .Bind<EnemyAttackComponent>()
                .AsSingle().WithArguments(_setings.AttckAnimations)
                .NonLazy();

            Container
                .Bind<EnemyChaseComponent>()
                .AsSingle()
                .WithArguments(_setings.CahaseSpeed)
                .NonLazy();

            Container
                .Bind<EnemyPatrolComponent>()
                .AsSingle()
                .WithArguments(_setings.PatrolSpeed)
                .NonLazy();

            Container
                .Bind<EnemyStateManager>()
                .AsSingle()
                .WithArguments(_setings.ChaseRange, _setings.AttckRange)
                .NonLazy();
        }
    }
}