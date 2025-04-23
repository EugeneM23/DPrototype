using Zenject;

namespace Gameplay
{
    public class PlayerWeponInstaller : Installer<Weapon, PlayerWeponInstaller>
    {
        [Inject] private readonly Weapon _weapon;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerWeponController>()
                .AsSingle()
                .WithArguments(_weapon)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerTargetController>()
                .AsSingle()
                .NonLazy();
        }
    }
}