using Modules;
using Player;
using Zenject;

namespace Game
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
                .WithArguments(10f)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerMoveController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<RotationComponent>()
                .AsSingle()
                .WithArguments(_player.Transform, _playerSetings.RotationSpeed)
                .NonLazy();

            Container
                .Bind<LeanComponent>()
                .AsSingle()
                .WithArguments(_player.Transform)
                .NonLazy();


            Container
                .Bind<LookAtComponent>()
                .AsSingle()
                .WithArguments(_player.Transform, _playerSetings.LookAtSpeed)
                .NonLazy();
        }
    }
}