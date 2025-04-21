using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class PlayerWeaponInstaller : MonoInstaller
    {
        [SerializeField] private Bullet _bulletPrefab;

        public override void InstallBindings()
        {
            GameObject go = new GameObject("BulletPool");

            Container
                .BindMemoryPool<Bullet, BulletPool>()
                .FromComponentInNewPrefab(_bulletPrefab)
                .UnderTransform(go.transform).AsSingle();

            Container.Bind<IBulletSpawner>().To<BulletPool>().FromResolve();
        }
    }
}