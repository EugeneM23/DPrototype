using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerSpawnInstaller : Installer<Transform, PlayerSpawnInstaller>
    {
        [Inject] private Transform _player;

        public override void InstallBindings()
        {
            Container
                .Bind<Transform>()
                .FromComponentInNewPrefab(_player).AsSingle().NonLazy();
        }
    }
}