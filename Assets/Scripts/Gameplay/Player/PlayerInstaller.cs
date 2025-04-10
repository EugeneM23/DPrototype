using Zenject;

namespace Gameplay
{
    public class PlayerInstaller : Installer<Player, PlayerParameters, PlayerInstaller>
    {
        [Inject] private Player _player;
        [Inject] private PlayerParameters _parameters;

        public override void InstallBindings()
        {
            Container.Bind<Player>()
                .FromComponentInNewPrefab(_player)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PlayerInput>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PlayerMoveComponent>()
                .AsSingle()
                .WithArguments(_parameters.Speed)
                .NonLazy();

            Container
                .Bind<PlayerRotationOnMoveComponent>()
                .AsSingle()
                .WithArguments(_parameters.RotationSpeed)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerLeanComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PlayerLookAtComponent>()
                .AsSingle()
                .WithArguments(_parameters.AimingSpeed)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerMoveController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerTargetController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerAnimationController>()
                .AsSingle()
                .NonLazy();
        }
    }
}