using Player;
using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayerHealthInstaller : Installer<Vector3, Transform, PlayerHealtBar, PlayerHealthInstaller>
    {
        [Inject] PlayerTransform _player;
        [Inject] private PlayerHealtBar _playerHealtBar;
        [Inject] private Transform _parent;
        [Inject] private Vector3 _hpBarOffset;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerDeathController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerTakeDamageController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PlayerHealtBar>()
                .FromComponentInNewPrefab(_playerHealtBar)
                .UnderTransform(_parent)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerHPBarPComponent>()
                .AsSingle().WithArguments(_hpBarOffset, _parent)
                .NonLazy();
        }
    }
}