using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private GameObject[] _enemyPrefabs;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyManager>().AsSingle().WithArguments(_enemyPrefabs).NonLazy();
        }
    }
}