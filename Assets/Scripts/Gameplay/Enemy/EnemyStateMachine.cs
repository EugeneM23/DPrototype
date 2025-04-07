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
        public bool IsOnAnimation;

        private Dictionary<Type, IEnemyState> _states;
        private GameObject _player;
        private IEnemyState _currentState;

        private void Start()
        {
            _player = _enemy.Target;
            _states = new Dictionary<Type, IEnemyState>()
            {
                [typeof(PatrolState)] = new PatrolState(_enemy, this),
                [typeof(ChaseState)] = new ChaseState(_player, _enemy, this),
                [typeof(AttackState)] = new AttackState(_player, _enemy, this),
            };

            SetState<PatrolState>();
        }

        public void SetState<T>() where T : IEnemyState
        {
            if (_currentState?.GetType() == typeof(T)) return;

            _currentState?.Exit();
            _currentState = _states[typeof(T)];
            _currentState.Enter();
        }

        public void Update()
        {
            var distance = Vector3.Distance(_player.transform.position, _enemy.transform.position);

            if (distance < _enemy.Attckrange)
                SetState<AttackState>();


            if (distance > _enemy.Attckrange)
                SetState<ChaseState>();

            if (distance > _enemy.ChaseRange)
                SetState<PatrolState>();

            _currentState?.Tick();
        }
    }
}