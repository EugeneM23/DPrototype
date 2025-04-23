using Zenject;

namespace Gameplay
{
    public class PlayerHealthInstaller : Installer<HPBar, PlayerHealthInstaller>
    {
        [Inject] private HPBar _hpBar;
        [Inject] PlayerTransform _player;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerDeathObserver>()
                .AsSingle()
                .NonLazy();


            Container
                .Bind<HPBar>()
                .FromComponentInNewPrefab(_hpBar)
                .UnderTransform(_player.Transform)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerTakeDamageController>()
                .AsSingle()
                .NonLazy();
        }
    }
}