using DamageNumbersPro;
using Gameplay.Modules;
using Player;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class
        PlayerHealthInstaller : Installer<int, Vector3, Transform, PlayerHealtBar, DamageNumber, PlayerHealthInstaller>
    {
        [Inject] PlayerTransform _player;
        [Inject] private PlayerHealtBar _playerHealtBar;
        [Inject] private Transform _parent;
        [Inject] private Vector3 _hpBarOffset;
        [Inject] private int _maxHealth;
        [Inject] private DamageNumber _damageNumber;

        public override void InstallBindings()
        {
            Container
                .Bind<DamageNumberSpawner>()
                .AsSingle()
                .WithArguments(_damageNumber, _player.transform)
                .NonLazy();

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
                .WithArguments(_maxHealth)
                .NonLazy();

            Container
                .Bind<IHealth>()
                .To<Health>()
                .AsSingle()
                .WithArguments(_maxHealth)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerHPBarPComponent>()
                .AsSingle().WithArguments(_hpBarOffset, _parent)
                .NonLazy();
        }
    }
}