using Gameplay;
using Zenject;

public class EnemyAnimationInstaller : Installer<EnemyAnimationInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<EnemyAnimationBehaviour>().AsSingle().NonLazy();
    }
}