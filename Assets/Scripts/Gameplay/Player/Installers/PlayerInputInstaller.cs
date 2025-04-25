using Zenject;

namespace Game
{
    public class PlayerInputInstaller : Installer<PlayerInputInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerInput>()
                .AsSingle()
                .NonLazy();
        }
    }
}