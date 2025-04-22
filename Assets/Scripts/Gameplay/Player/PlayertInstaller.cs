using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayertInstaller : MonoInstaller
    {
        [SerializeField] private PlayerHealthView _playerHealthView;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private ParticleSystem _hitEffect;
        [SerializeField] private PlayerSetings _playerSetings;

        public override void InstallBindings()
        {
            Container
                .Bind<PlayerMoveComponent>()
                .AsSingle()
                .WithArguments(10f)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<Player>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerLeanComponent>()
                .AsSingle()
                .NonLazy();

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
                .Bind<PlayerInput>()
                .AsSingle()
                .NonLazy();


            Container
                .Bind<PlayerRotationOnMoveComponent>()
                .AsSingle()
                .WithArguments(20f)
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

            Container.Bind<PlayerHitEffect>().AsSingle().WithArguments(_hitEffect).NonLazy();
        }

        [Serializable]
        public class PlayerSetings
        {
            [field: SerializeField] public float RunSpeed { get; private set; }
            [field: SerializeField] public float RotationSpeed { get; private set; }
            [field: SerializeField] public float StrafeSpeed { get; private set; }
            [field: SerializeField] public float StrafePower { get; private set; }
            [field: SerializeField] public int MaxHealth { get; private set; }
        }
    }
}