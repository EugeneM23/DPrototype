using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyManager>().AsSingle().NonLazy();
        }
    }
}