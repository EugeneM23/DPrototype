using Modules.PrefabPool;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;
        [SerializeField] private PlayerParameters _parameters;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerStateMachine>().AsSingle().WithArguments(_parameters).NonLazy();
            Container.Bind<Player>().FromComponentInNewPrefab(_player).AsSingle().NonLazy();
            Container.Bind<PlayerMoveComponent>().AsSingle().WithArguments(_parameters.Speed).NonLazy();
            Container.Bind<PlayerRotationOnMoveComponent>().AsSingle().WithArguments(_parameters.RotationSpeed).NonLazy();
            Container.Bind<PlayerLookAtComponent>().AsSingle().WithArguments(_parameters.AimingSpeed).NonLazy();
            Container.Bind<PlayerInput>().AsSingle().NonLazy();
            Container.Bind<Bulletmanager>().AsSingle().NonLazy();
            Container.Bind<PrefabPool>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<PlayerMoveController>().AsSingle().NonLazy();
        }
    }
}