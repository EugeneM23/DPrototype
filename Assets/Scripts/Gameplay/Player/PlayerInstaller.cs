using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _HUD;
        [SerializeField] private PlayerParameters _parameters;

        public override void InstallBindings()
        {
            Instantiate(_HUD);

            Container.BindInterfacesAndSelfTo<PlayerStateMachine>().AsSingle().NonLazy();
            Container.Bind<Player>().FromComponentInNewPrefab(_player).AsSingle().NonLazy();
            Container.Bind<PlayerMoveComponent>().AsSingle().WithArguments(_parameters.Speed).NonLazy();
            Container.Bind<RotationComponent>().AsSingle().WithArguments(_parameters.RotationSpeed).NonLazy();
            Container.Bind<PlayerLookAtComponent>().AsSingle().WithArguments(_parameters.AimingSpeed).NonLazy();
            Container.Bind<PlayerInput>().AsSingle().NonLazy();

            Container
                .BindInterfacesAndSelfTo<CameraFolower>()
                .AsSingle()
                .WithArguments(Camera.main.gameObject.transform)
                .NonLazy();
        }
    }

    [Serializable]
    public class PlayerParameters
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float AimingSpeed { get; private set; }
    }
}