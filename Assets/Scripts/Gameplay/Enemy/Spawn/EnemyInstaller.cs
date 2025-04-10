using Gameplay.BehComponents;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private float _chaseRange = 10;
        [SerializeField] private float _attckRange = 3;

        public override void InstallBindings()
        {
            Container.Bind<PatrolComponent>().AsSingle().NonLazy();
            Container.Bind<AttackComponent>().AsSingle().NonLazy();
            Container.Bind<ChaseComponent>().AsSingle().NonLazy();
            Container.Bind<EnemyConditions>().AsSingle().WithArguments(_chaseRange, _attckRange).NonLazy();
            Container.Bind<RotationToTarget>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<EnemyAnimationController>().AsSingle().NonLazy();
        }
    }
}