using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class CameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<CameraFolower>()
                .AsSingle()
                .WithArguments(Camera.main.gameObject.transform)
                .NonLazy();
        }
    }
}