using Zenject;

namespace Gameplay
{
    public class PlayerInstaller : Installer<Player, PlayerInstaller>
    {
        [Inject] private Player _player;

        public override void InstallBindings()
        {
            Container.Bind<Player>()
                .FromComponentInNewPrefab(_player)
                .AsSingle()
                .NonLazy();
        }
    }
}