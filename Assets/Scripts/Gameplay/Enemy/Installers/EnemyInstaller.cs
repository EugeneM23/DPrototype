using Gameplay;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private float _chaseRange = 10;
    [SerializeField] private float _attckRange = 3;
    [SerializeField] private float _cahaseSpeed = 5;
    [SerializeField] private float _patrolSpeed = 2;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<Enemy>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<EnemyStateObserver>()
            .AsSingle()
            .WithArguments(_chaseRange, _attckRange)
            .NonLazy();

        Container
            .Bind<PatrolComponent>()
            .AsSingle()
            .WithArguments(_patrolSpeed)
            .NonLazy();

        Container
            .Bind<ChaseComponent>()
            .AsSingle()
            .WithArguments(_cahaseSpeed)
            .NonLazy();
        
        Container
            .Bind<AttackComponent>()
            .AsSingle()
            .NonLazy();
        Container
            .Bind<RotationToTarget>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<EnemyPatrolPointManager>()
            .AsSingle()
            .NonLazy();
    }
}