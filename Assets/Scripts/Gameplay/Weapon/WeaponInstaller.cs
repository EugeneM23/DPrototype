using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private WeaponSetings _setings;

        public override void InstallBindings()
        {
            Container
                .Bind<WeaponSetings>()
                .FromInstance(_setings)
                .AsSingle()
                .NonLazy();

            GameObject go = new GameObject("BulletPool");

            Container
                .BindMemoryPool<Bullet, BulletPool>()
                .FromComponentInNewPrefab(_setings.BulletPrefab)
                .UnderTransform(go.transform);

            Container
                .Bind<IBulletSpawner>()
                .To<BulletPool>()
                .FromResolve();

            Container
                .BindMemoryPool<Shell, ShellPool>()
                .FromComponentInNewPrefab(_setings.ShellPrefab)
                .UnderTransform(go.transform);

            Container
                .Bind<IShellSpawner>()
                .To<ShellPool>()
                .FromResolve();

            Container.Bind<WeaponFireController>().AsSingle().NonLazy();
        }
    }
}