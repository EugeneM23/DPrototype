using Gameplay;
using Zenject;

public class EnemyStateInstaller : Installer<EnemySetings, EnemyStateInstaller>
{
    [Inject] private EnemySetings _setings;

    public override void InstallBindings()
    {
        Container
            .Bind<EnemyAttackComponent>()
            .AsSingle()
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