using Gameplay;
using UnityEngine;
using Zenject;

public class BulletInstaller : MonoInstaller
{
    [SerializeField] private int _maxRicochets = 2;

    public override void InstallBindings()
    {
        Container
            .Bind<BulletMoveComponent>()
            .AsSingle()
            .WithArguments(this.transform)
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<BulletRicochetComponent>()
            .AsSingle()
            .WithArguments(this.transform, _maxRicochets)
            .NonLazy();
    }
}