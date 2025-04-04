using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private Enemy _enemyPrefab;
        public override void InstallBindings()
        {
            for (int i = 0; i < 1; i++)
            {
                Container.Bind<Enemy>().FromComponentInNewPrefab(_enemyPrefab).AsCached().NonLazy();
            }
        }
    }
}