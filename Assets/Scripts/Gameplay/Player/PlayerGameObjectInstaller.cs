using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerGameObjectInstaller : MonoInstaller
    {
        [SerializeField] private PlayerHealthView _playerHealthView;
        [SerializeField] private Weapon _weapon;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerTakeDamageController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PlayerHealthView>()
                .FromComponentInNewPrefab(_playerHealthView)
                .UnderTransform(transform)
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerDeathObserver>().AsSingle().NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerWeponController>().AsSingle().WithArguments(_weapon).NonLazy();

            Container
                .Bind<PlayerMoveComponent>()
                .AsSingle()
                .WithArguments(10f)
                .NonLazy();

            Container
                .Bind<PlayerInput>()
                .AsSingle()
                .NonLazy();


            Container
                .Bind<PlayerRotationOnMoveComponent>()
                .AsSingle()
                .WithArguments(20f)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerLeanComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PlayerLookAtComponent>()
                .AsSingle()
                .WithArguments(600f)
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