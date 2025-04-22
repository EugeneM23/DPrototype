using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CameraInstaller : Installer<float, Camera, CameraInstaller>
    {
        [Inject] private float _smoothTime;
        [Inject] private Camera _camera;

        public override void InstallBindings()
        {
            Transform cameraTransfrom = _camera.gameObject.transform;

            Container
                .BindInterfacesAndSelfTo<CameraFollower>()
                .AsSingle()
                .WithArguments(cameraTransfrom, _smoothTime)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<CameraShakeComponent>()
                .AsSingle()
                .WithArguments(cameraTransfrom)
                .NonLazy();
        }
    }
}