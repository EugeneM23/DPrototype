using Gameplay.BehComponents;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private Transform[] _patrolPoints;
        private float _chaseRange = 10;
        private float _attckRange = 3;

        public override void InstallBindings()
        {
            var instance = Container.InstantiatePrefab(_enemyPrefab);

            Container.Bind<NavMeshAgent>().FromInstance(instance.GetComponent<NavMeshAgent>()).AsSingle();
            Container.Bind<Animator>().FromInstance(instance.GetComponent<Animator>()).AsSingle();
            Container.Bind<Transform>().FromInstance(instance.transform).AsSingle();
            Container.Bind<AttackAnimationProvider>().FromInstance(instance.GetComponent<AttackAnimationProvider>())
                .AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<Enemy>().AsSingle().WithArguments(_chaseRange, _attckRange).NonLazy();
            Container.Bind<EnemyPatrolPointManager>().AsSingle().WithArguments(_patrolPoints).NonLazy();
            Container.Bind<EnemyBehaviour>().AsSingle().NonLazy();

            Container.Bind<EnemyConditions>().AsSingle().WithArguments(_chaseRange, _attckRange).NonLazy();

            Container.Bind<PatrolComponent>().AsSingle().NonLazy();
            Container.Bind<ChaseComponent>().AsSingle().NonLazy();
            Container.Bind<AttackComponent>().AsSingle().NonLazy();
            Container.Bind<RotationToTarget>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<EnemyAnimationController>().AsSingle().NonLazy();
        }
    }
}