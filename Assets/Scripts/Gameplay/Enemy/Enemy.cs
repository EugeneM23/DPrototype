using System;
using Modules.PrefabPool;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class Enemy : MonoBehaviour, IDespawned
    {
        public event Action<GameObject> DeSpawn;

        [SerializeField] private EnemyAnimationController _animationController;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private EnemyStateMachine _stateMachine;

        [field: SerializeField] public float ChaseRange { get; private set; }
        [field: SerializeField] public float Attckrange { get; private set; }

        public GameObject Target => _target;

        private GameObject _target;

        public void SetDestination(Vector3 transformPosition) => _agent.SetDestination(transformPosition);

        public void SetTarget(GameObject target) => _target = target;

        public void Despawn(GameObject obj) => DeSpawn?.Invoke(gameObject);

        public float GetVelocity() => _agent.velocity.magnitude;

        public void SetSpeed(int i) => _agent.speed = i;

        public void Destroy()
        {
        }

        public void AgentStop() => _agent.isStopped = true;
        public void AgentStarg() => _agent.isStopped = false;
    }
}