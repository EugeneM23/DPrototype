using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerGameObjectInstaller : MonoInstaller
    {
        [SerializeField] private PlayerHealthView _playerHealthView;

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
        }
    }
}