using DPrototype.Game;
using Gameplay;
using UnityEngine;
using Zenject;

namespace Game
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
            PlayerSpawnInstaller.Install(Container, _playerPrefab);
            CameraInstaller.Install(Container, _cameraSmoothTime, _camera);
        }
    }
}