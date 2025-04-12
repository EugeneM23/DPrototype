using Zenject;

namespace Gameplay
{
    public class CameraInstaller : Installer<CameraInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<CameraFollower>()
                .AsSingle()
                .WithArguments(UnityEngine.Camera.main.gameObject.transform)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<CameraShakeComponent>()
                .AsSingle()
                .NonLazy();
        }
    }
}