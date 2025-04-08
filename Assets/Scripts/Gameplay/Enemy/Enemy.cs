using System;
using Gameplay.BehComponents;
using Modules.PrefabPool;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class Enemy : MonoBehaviour, IDespawned
    {
        public event Action<GameObject> DeSpawn;

        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _chaseRange;
        [SerializeField] private float _attckrange;

        private readonly EnemyPatrolPointManager _patrolPointManager = new();

        private EnemyConditions _conditions;
        private PatrolComponent _patrolState;
        private AttackComponent _attackState;
        private ChaseComponent _chaseComponent;

        private GameObject _target;
        private EnemyAnimationController _animationController;
        public Transform Target => _target.transform;

        private void Start()
        {
            _conditions =
                new EnemyConditions(
                    player: _target.transform,
                    enemy: gameObject.transform,
                    chaseRange: _chaseRange,
                    attckRange: _attckrange);

            _patrolState = new PatrolComponent(_agent, _conditions, _patrolPointManager);
            _attackState = new AttackComponent(_conditions, _agent, new RotationToTarget());
            _chaseComponent = new ChaseComponent(_agent, _conditions, _target);
            _animationController = new EnemyAnimationController(GetComponent<Animator>(), _conditions);
        }

        public void SetTarget(GameObject target) => _target = target;

        private void Update()
        {
            if (_conditions.GetPatrolCondition())
            {
                Debug.Log("Patrol");
                _patrolState.Patrol();
            }

            if (_conditions.GetChaseCondition())
                _chaseComponent.Chase();

            if (_conditions.GetAttackCondition())
                _attackState.Attack();
            
            _animationController.Tick();
        }

        public void FinishAttackAnimation() => _conditions.IsAttaking = false;

        public void StartAttackAnimation() => _conditions.IsAttaking = true;
        public void SetSpawnPoints(Transform[] patrolPoints) => _patrolPointManager.SetPatrolPoints(patrolPoints);
        public void Despawn(GameObject obj) => DeSpawn?.Invoke(gameObject);

        public void Destroy()
        {
        }
    }
}