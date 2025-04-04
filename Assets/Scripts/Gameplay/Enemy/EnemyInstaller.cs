using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private Enemy _enemyPrefab;
    public override void InstallBindings()
    {
        for (int i = 0; i < 10; i++)
        {
            Container.Bind<Enemy>().FromComponentInNewPrefab(_enemyPrefab).AsCached().NonLazy();
        }
    }
}