using DPrototype.Game;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private int _maximumFPS = 100;
        [SerializeField] private PlayerTransform _playerPrefab;
        [SerializeField] private GameObject _HUD;
        [SerializeField] private float _cameraSmoothTime;
        [SerializeField] private Camera _camera;

        public override void InstallBindings()
        {
            Application.targetFrameRate = _maximumFPS;
            UIInstaller.Install(Container, _HUD);
            CameraInstaller.Install(Container, _cameraSmoothTime, _camera);
            PlayerSpawnInstaller.Install(Container, _playerPrefab);
        }
    }
}