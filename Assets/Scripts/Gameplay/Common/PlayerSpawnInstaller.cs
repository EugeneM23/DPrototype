using Game;
using UnityEngine;
using Zenject;

namespace DPrototype.Game
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