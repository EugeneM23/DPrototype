using Gameplay.BehComponents;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    /*public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _chaseRange = 10;
        [SerializeField] private float _attckRange = 3;
        [SerializeField] private int _chaseSpeend;
        [SerializeField] private string[] _attackAnimations;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Enemy>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<EnemyDeathObserver>().AsSingle().NonLazy();

            Container
                .Bind<EnemyDamage>()
                .AsSingle()
                .WithArguments(_damage);

            Container
                .Bind<PatrolComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<EnemyConditions>()
                .AsSingle()
                .WithArguments(_chaseRange, _attckRange)
                .NonLazy();

            Container
                .Bind<AttackComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<ChaseComponent>()
                .AsSingle().WithArguments(_chaseSpeend)
                .NonLazy();


            Container
                .Bind<RotationToTarget>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyAnimationController>()
                .AsSingle()
                .WithArguments(_attackAnimations)
                .NonLazy();
        }
    }

    public class EnemyDamage
    {
        public int Damage { get; }

        public EnemyDamage(int damage) => Damage = damage;
    }*/
}