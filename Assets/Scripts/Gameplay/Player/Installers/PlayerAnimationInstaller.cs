using Zenject;

namespace Game
{
    public class PlayerAnimationInstaller : Installer<PlayerAnimationInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerAnimationBehaviour>()
                .AsSingle()
                .NonLazy();
        }
    }
}