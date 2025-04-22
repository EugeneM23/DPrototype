using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private int _maximumFPS = 100;
        [SerializeField] private PlayerParameters _parameters;
        [SerializeField] private GameObject _HUD;

        public override void InstallBindings()
        {
            Application.targetFrameRate = _maximumFPS;
            
            UIInstaller.Install(Container, _HUD);
            PlayerInstaller.Install(Container, _playerPrefab, _parameters);
            EnemyManagerInstaller.Install(Container);
            CameraInstaller.Install(Container);
        }
    }
}