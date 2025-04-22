using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private int _maximumFPS = 100;
        [SerializeField] private GameObject _HUD;
        [SerializeField] private float _cameraSmoothTime;
        [SerializeField] private Camera _camera;

        public override void InstallBindings()
        {
            Application.targetFrameRate = _maximumFPS;

            UIInstaller.Install(Container, _HUD);
            PlayerInstaller.Install(Container, _playerPrefab);
            EnemyManagerInstaller.Install(Container);
            CameraInstaller.Install(Container, _cameraSmoothTime, _camera);
        }
    }
}