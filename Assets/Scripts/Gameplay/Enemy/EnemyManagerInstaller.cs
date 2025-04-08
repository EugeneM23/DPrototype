using Zenject;

namespace Gameplay
{
    public class EnemyManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyManager>().AsSingle().NonLazy();
        }
    }
}