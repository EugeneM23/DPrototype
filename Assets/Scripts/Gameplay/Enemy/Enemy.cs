using System;
using Gameplay.Common;
using Modules.PrefabPool;
using UnityEngine;

namespace Gameplay
{
    public class Enemy : MonoBehaviour, IDespawned
    {
        public event Action<GameObject> DeSpawn;

        [SerializeField] private LootExplosionComponent _loot;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private EnemyAnimationController _animationController;

        private GameObject _target;
        private EnemyStateMachine _stateMachine;
        public bool IsRuning { get; set; }
        public bool IsWalking { get; set; }
        public bool IsAidling { get; set; }
        public bool IsAttaking { get; set; }
        public bool Is { get; set; }
        public bool IsOnAnimation { get; set; }

        private void Start()
        {
            _stateMachine = new EnemyStateMachine(_target, GetComponent<EnemyBrain>(), this);
            _animationController.SetEnemy(this);
        }

        private void Update()
        {
            _stateMachine.Tick();
        }

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

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        private void Despawn(GameObject obj)
        {
            DeSpawn?.Invoke(gameObject);
        }

        public void Destroy()
        {
        }
    }
}