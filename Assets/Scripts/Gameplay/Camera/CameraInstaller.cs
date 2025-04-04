using Zenject;

namespace Gameplay
{
    public class CameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<CameraFolower>()
                .AsSingle()
                .WithArguments(UnityEngine.Camera.main.gameObject.transform)
                .NonLazy();
        }
    }
}