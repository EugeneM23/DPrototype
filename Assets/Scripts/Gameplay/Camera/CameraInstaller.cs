using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CameraInstaller : Installer<float, Camera, CameraInstaller>
    {
        [Inject] private float _smoothTime;
        [Inject] private Camera _camera;
        [Inject] private PlayerTransform _target;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerCamera>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<ObjectFollowComponent>()
                .AsSingle()
                .WithArguments(_camera.transform, _target.Transform, _smoothTime)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<CameraShakeComponent>()
                .AsSingle()
                .WithArguments(_camera)
                .NonLazy();
        }
    }
}