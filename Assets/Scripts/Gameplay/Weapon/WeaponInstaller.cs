using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Shell _shellPrefab;

        public override void InstallBindings()
        {
            GameObject go = new GameObject("BulletPool");

            Container
                .BindMemoryPool<Bullet, BulletPool>()
                .FromComponentInNewPrefab(_bulletPrefab)
                .UnderTransform(go.transform);

            Container.Bind<IBulletSpawner>().To<BulletPool>().FromResolve();

            Container
                .BindMemoryPool<Shell, ShellPool>()
                .FromComponentInNewPrefab(_shellPrefab)
                .UnderTransform(go.transform);


            Container.Bind<IShellSpawner>().To<ShellPool>().FromResolve();
        }
    }
}