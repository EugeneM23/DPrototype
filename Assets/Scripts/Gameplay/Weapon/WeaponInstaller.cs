using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Transform _shellPoint;
        [SerializeField] private WeaponSetings _setings;

        [Inject] private ShellPrefabhandler _shellPrefabhandler;
        [Inject] private BulletPrefabHandler _bulletPrefabHandler;
        [Inject] private Transform _player;

        public override void InstallBindings()
        {
            GameObject go = new GameObject("BulletPool");

            Container
                .BindInterfacesTo<Weapon>()
                .AsSingle().WithArguments(_firePoint, _shellPoint, _setings)
                .NonLazy();

            Container
                .BindMemoryPool<Bullet, BulletPool>()
                .FromComponentInNewPrefab(_bulletPrefabHandler.BulletPrefab)
                .UnderTransform(go.transform);

            Container
                .Bind<IBulletSpawner>()
                .To<BulletPool>()
                .FromResolve();

            Container
                .BindMemoryPool<Shell, ShellPool>()
                .FromComponentInNewPrefab(_shellPrefabhandler.ShellPrefab)
                .UnderTransform(go.transform);

            Container
                .Bind<IShellSpawner>()
                .To<ShellPool>()
                .FromResolve();
        }
    }
}