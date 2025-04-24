using Gameplay;
using Zenject;

public class EnemyHealthInstaller : Installer<EnemyHealthInstaller>
{
    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<EnemyDeathObserver>()
            .AsSingle()
            .NonLazy();
    }
}