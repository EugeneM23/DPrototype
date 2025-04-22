using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CameraInstaller : Installer<CameraInstaller>
    {
        public override void InstallBindings()
        {
            Transform cameraTransfrom = UnityEngine.Camera.main.gameObject.transform;

            Container
                .BindInterfacesAndSelfTo<CameraFollower>()
                .AsSingle()
                .WithArguments(cameraTransfrom)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<CameraShakeComponent>()
                .AsSingle()
                .WithArguments(cameraTransfrom)
                .NonLazy();
        }
    }
}