using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay
{
    public class PlayerWeaponInstaller : MonoInstaller
    {
        [SerializeField] private Bullet _enemyPrefab;

        public override void InstallBindings()
        {
            GameObject go = new GameObject("BulletPool");

            Container
                .BindMemoryPool<Bullet, BulletPool>()
                .FromComponentInNewPrefab(_enemyPrefab)
                .UnderTransform(go.transform).AsSingle();
            
            Container.Bind<IBulletSpawner>().To<BulletPool>().FromResolve();
        }
    }
}