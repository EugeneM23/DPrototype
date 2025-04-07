using System;
using Gameplay.Common;
using Modules.PrefabPool;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class Enemy : MonoBehaviour, IDespawned
    {
        public event Action<GameObject> DeSpawn;

        [SerializeField] private LootExplosionComponent _loot;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private EnemyAnimationController _animationController;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private EnemyStateMachine _stateMachine;

        [field: SerializeField] public float ChaseRange { get; private set; }
        [field: SerializeField] public float Attckrange { get; private set; }

        public bool IsRuning { get; set; }
        public bool IsWalking { get; set; }
        public bool IsAidling { get; set; }
        public bool IsAttaking { get; set; }
        public bool IsOnAnimation { get; set; }
        public GameObject Target => _target;

        private GameObject _target;

        private void OnEnable()
        {
            _healthComponent.DeSpawn += Despawn;
            _healthComponent.DeSpawn += _loot.SpawnLoot;
        }

        private void OnDisable()
        {
            _healthComponent.DeSpawn -= Despawn;
            _healthComponent.DeSpawn -= _loot.SpawnLoot;
        }

        private void Start() => _animationController.SetEnemy(this);

        public void SetDestination(Vector3 transformPosition) => _agent.SetDestination(transformPosition);

        public void SetTarget(GameObject target) => _target = target;

        private void Despawn(GameObject obj) => DeSpawn?.Invoke(gameObject);

        public float GetVelocity() => _agent.velocity.magnitude;

        public void SetSpeed(int i) => _agent.speed = i;

        public void Destroy()
        {
        }
    }
}