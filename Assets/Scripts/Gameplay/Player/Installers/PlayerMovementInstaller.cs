using Game;
using Modules;
using Zenject;

namespace Gameplay
{
    public class PlayerMovementInstaller : Installer<PlayerSetings, PlayerMovementInstaller>
    {
        [Inject] private PlayerTransform _player;
        [Inject] private PlayerSetings _playerSetings;

        public override void InstallBindings()
        {
            Container
                .Bind<MoveComponent>()
                .AsSingle()
                .WithArguments(_playerSetings.RunSpeed)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerMoveController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<RotationComponent>()
                .AsSingle()
                .WithArguments(_player.transform, _playerSetings.RotationSpeed)
                .NonLazy();

            Container
                .Bind<LeanComponent>()
                .AsSingle()
                .WithArguments(_player.transform)
                .NonLazy();


            Container
                .Bind<LookAtComponent>()
                .AsSingle()
                .WithArguments(_player.transform, _playerSetings.LookAtSpeed)
                .NonLazy();
        }
    }
}