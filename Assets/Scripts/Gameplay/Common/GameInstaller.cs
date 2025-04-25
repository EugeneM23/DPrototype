using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private int _maximumFPS = 100;
        [SerializeField] private Transform _playerPrefab;
        [SerializeField] private GameObject _HUD;
        [SerializeField] private float _cameraSmoothTime;
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _weaponPrefab;

        public override void InstallBindings()
        {
            Application.targetFrameRate = _maximumFPS;

            Container.Bind<PlayerWeponController>().AsSingle().NonLazy();
            UIInstaller.Install(Container, _HUD);
            PlayerSpawnInstaller.Install(Container, _playerPrefab);
            WeaponSpawnInstaller.Install(Container, _weaponPrefab);
            CameraInstaller.Install(Container, _cameraSmoothTime, _camera);
            Container.BindInterfacesTo<WeaponManager>().AsSingle().NonLazy();
        }
    }

    public class WeaponManager : IInitializable
    {
        [Inject] private readonly PlayerWeponController _playerWeponController;

        public void Initialize()
        {
            _playerWeponController.SetWeaponToPlayer();
        }
    }

    public class WeaponSpawnInstaller : Installer<GameObject, WeaponSpawnInstaller>
    {
        [Inject] private readonly GameObject _weaponPrefab;
        [Inject] private Transform _player;

        public override void InstallBindings()
        {
            GameObject weapon = Container.InstantiatePrefab(_weaponPrefab);
            weapon.transform.SetParent(_player);
        }
    }
}