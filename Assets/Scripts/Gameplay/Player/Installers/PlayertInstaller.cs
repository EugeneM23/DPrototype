using Modules;
using Player;
using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayertInstaller : MonoInstaller
    {
        [SerializeField] private HPBar _hpBar;
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
            PlayerHealthInstaller.Install(Container);
            PlayerAnimationInstaller.Install(Container);
            PlayerEffectsInstaller.Install(Container, _hitEffect);
            HPBarInstaller.Install(Container, _healtBarOffset, gameObject.transform, _hpBar);

            Container.Bind<PlayerWeaponManager>().AsSingle().WithArguments(Container, _weaponPrefab)
                .NonLazy();

            Container.Bind<PlayerCameraController>().AsSingle().NonLazy();
        }
    }
}