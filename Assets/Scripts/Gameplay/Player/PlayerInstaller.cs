using Zenject;

namespace Gameplay
{
    public class PlayerInstaller : Installer<Player, PlayerParameters, PlayerInstaller>
    {
        [Inject] private Player _player;
        [Inject] private PlayerParameters _parameters;

        public override void InstallBindings()
        {
            Container.Bind<Player>().FromComponentInNewPrefab(_player).AsSingle().NonLazy();
            Container.Bind<PlayerMove>().AsSingle().WithArguments(_parameters.Speed).NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerMoveController>().AsSingle().NonLazy();
            Container.Bind<PlayerInput>().AsSingle().NonLazy();

            Container.Bind<PlayerRotationOnMove>().AsSingle().WithArguments(_parameters.RotationSpeed)
                .NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerAnimationController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerTargetController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerLean>().AsSingle().NonLazy();
            Container.Bind<PlayerLookAt>().AsSingle().WithArguments(_parameters.AimingSpeed).NonLazy();
        }
    }
}