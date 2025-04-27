using Zenject;

namespace Gameplay
{
    public class PlayerSpawnInstaller : Installer<PlayerTransform, PlayerSpawnInstaller>
    {
        [Inject] private PlayerTransform _player;

        public override void InstallBindings()
        {
            Container
                .Bind<PlayerTransform>()
                .FromComponentInNewPrefab(_player).AsSingle().NonLazy();
        }
    }
}