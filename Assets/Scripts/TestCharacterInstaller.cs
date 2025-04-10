using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace DefaultNamespace
{
    public class TestCharacterInstaller : MonoInstaller
    {
        [SerializeField] private Transform _transform;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TestMove>().AsSingle().NonLazy();
        }
    }

    public class TestMove : IInitializable, ITickable
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly Transform _transform;

        public TestMove(NavMeshAgent navMeshAgent)
        {
            _navMeshAgent = navMeshAgent;
        }
        

        public void Initialize()
        {
            _navMeshAgent.SetDestination(new Vector3(0, 0, 18));
        }

        public void Tick()
        {
            Debug.Log(_navMeshAgent.velocity);
        }
    }
}