using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class TestSceneContext : MonoInstaller
    {
        [SerializeField] private Transform _playerPrefab;

        public override void InstallBindings()
        {
            Container.Bind<Transform>().FromComponentInNewPrefab(_playerPrefab).AsSingle().NonLazy();
        }
    }
}