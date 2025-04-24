using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class PlayertInstaller : MonoInstaller
    {
        [SerializeField] private HPBar _hpBar;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private ParticleSystem _hitEffect;
        [SerializeField] private PlayerSetings _playerSetings;
        [SerializeField] private Vector3 _healtBarOffset;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Player>()
                .AsSingle()
                .NonLazy();

            PlayerInputInstaller.Install(Container);
            PlayerMovementInstaller.Install(Container, _playerSetings);
            PlayerHealthInstaller.Install(Container);
            PlayerWeponInstaller.Install(Container, _weapon);
            PlayerAnimationInstaller.Install(Container);
            PlayerEffectsInstaller.Install(Container, _hitEffect);

            HPBarInstaller.Install(Container, _healtBarOffset, gameObject.transform, _hpBar);
        }
    }
}