using Zenject;

namespace Gameplay
{
    public class PlayerInstaller : Installer<Player, PlayerParameters, PlayerInstaller>
    {
        [Inject] private Player _player;
        [Inject] private PlayerParameters _parameters;

        public override void InstallBindings()
        {
            Container.Bind<Player>()
                .FromComponentInNewPrefab(_player)
                .AsSingle()
                .NonLazy();

         
        }
    }
}