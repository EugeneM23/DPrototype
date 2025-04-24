using Zenject;

namespace Gameplay
{
    public class EnemyManagerInstaller : Installer<EnemyManagerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyManager>()
                .AsSingle()
                .NonLazy();
        }
    }
}