using Game;
using Gameplay;
using Modules;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class PlayertInstaller : MonoInstaller
    {
        [SerializeField] private PlayerHealtBar playerHealtBar;
        [SerializeField] private ParticleSystem _hitEffect;
        [SerializeField] private PlayerSetings _playerSetings;
        [SerializeField] private Vector3 _healtBarOffset;
        [SerializeField] private GameObject _weaponPrefab;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Player>()
                .AsSingle()
                .NonLazy();

            PlayerInputInstaller.Install(Container);
            PlayerMovementInstaller.Install(Container, _playerSetings);
            PlayerHealthInstaller.Install(Container, _playerSetings.MaxHealth, _healtBarOffset, gameObject.transform,
                playerHealtBar);
            PlayerAnimationInstaller.Install(Container);
            PlayerEffectsInstaller.Install(Container, _hitEffect);

            Container
                .Bind<PlayerWeaponManager>()
                .AsSingle()
                .WithArguments(Container, _weaponPrefab)
                .NonLazy();

            Container
                .Bind<PlayerCameraController>()
                .AsSingle()
                .NonLazy();
        }
    }
}