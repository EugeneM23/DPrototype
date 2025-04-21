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
            
        }
    }
}