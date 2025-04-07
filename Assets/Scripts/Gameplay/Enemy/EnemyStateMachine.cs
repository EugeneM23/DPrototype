using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        private Dictionary<Type, IEnemyState> _states;
        private GameObject _player;

        private IEnemyState _currentState;

        private void Start()
        {
            _player = _enemy.Target;
            _states = new Dictionary<Type, IEnemyState>()
            {
                [typeof(PatrolState)] = new PatrolState(_enemy),
                [typeof(ChaseState)] = new ChaseState(_player, _enemy),
                [typeof(AttackState)] = new AttackState(_player, _enemy),
            };

            SetState<PatrolState>();
        }

        public void SetState<T>() where T : IEnemyState
        {
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