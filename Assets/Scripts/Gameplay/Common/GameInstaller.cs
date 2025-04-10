using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private int _maximumFPS = 100;
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private PlayerParameters _parameters;
        [SerializeField] private GameObject _HUD;

        public override void InstallBindings()
        {
            UIInstaller.Install(Container, _HUD);
            PlayerInstaller.Install(Container, _playerPrefab, _parameters);
            EnemyManagerInstaller.Install(Container);
            CameraInstaller.Install(Container);

            Application.targetFrameRate = _maximumFPS;
        }
    }
}