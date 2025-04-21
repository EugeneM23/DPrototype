using Gameplay;
using UnityEngine;
using Zenject;

public class BulletObjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BulletMoveComponent>().AsSingle().WithArguments(this.transform).NonLazy();
    }
}