using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;

        public bool IsRuning;
        public bool IsWalking;
        public bool IsAidling;
        public bool IsAttaking;

        private Dictionary<Type, EnemyBaseState> _states;
        private GameObject _player;
        private EnemyBaseState _currentState;
        public bool IsOnAnimation { get; set; }

        private void Start()
        {
            _player = _enemy.Target;
            _states = new Dictionary<Type, EnemyBaseState>()
            {
                [typeof(PatrolState)] = new PatrolState(_player, _enemy,this),
                [typeof(ChaseState)] = new ChaseState(_player, _enemy, this),
                [typeof(AttackState)] = new AttackState(_player, _enemy, this),
            };

            SetState<PatrolState>();
        }

        public void SetState<T>() where T : EnemyBaseState
        {
            if (_currentState?.GetType() == typeof(T)) return;

            _currentState?.Exit();
            _currentState = _states[typeof(T)];
            _currentState.Enter();
        }

        public void Update()
        {
            Debug.Log(_currentState.GetType().Name);
            _currentState?.Tick();
        }

        public bool PlayerInChaseRange()
        {
            return Vector3.Distance(transform.position, _player.transform.position) <= _enemy.ChaseRange;
        }

        public bool PlayerInAttackRange()
        {
            return Vector3.Distance(transform.position, _player.transform.position) <= _enemy.Attckrange;
        }
    }
}