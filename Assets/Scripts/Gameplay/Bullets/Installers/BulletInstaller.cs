using Gameplay;
using UnityEngine;
using Zenject;

public class BulletInstaller : MonoInstaller
{
    [SerializeField] private int _maxRicochets = 2;
    [SerializeField] private int _damage;

    public override void InstallBindings()
    {
        Container
            .Bind<BulletMoveComponent>()
            .AsSingle()
            .WithArguments(this.transform)
            .NonLazy();

        Container
            .Bind<BulletDamageComponent>()
            .AsSingle()
            .WithArguments(this._damage)
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<BulletRicochetComponent>()
            .AsSingle()
            .WithArguments(this.transform, _maxRicochets)
            .NonLazy();
    }
}