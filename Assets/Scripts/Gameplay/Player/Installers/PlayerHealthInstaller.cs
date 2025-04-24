using Zenject;

namespace Gameplay
{
    public class PlayerHealthInstaller : Installer< PlayerHealthInstaller>
    {
        [Inject] PlayerTransform _player;

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
        }
    }
}