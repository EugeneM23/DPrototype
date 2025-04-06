using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class EnemyStateMachine
    {
        private readonly EnemyBrain _brain;
        private readonly Dictionary<Type, IEnemyState> _states;

        private GameObject _player;
        private Enemy _enemy;

        private IEnemyState _currentState;

        public EnemyStateMachine(GameObject player, EnemyBrain brain, Enemy enemy)
        {
            _player = player;
            _brain = brain;
            _enemy = enemy;

            _states = new Dictionary<Type, IEnemyState>()
            {
                [typeof(PatrolState)] = new PatrolState(brain),
                [typeof(ChaseState)] = new ChaseState(player, brain),
                [typeof(AttackState)] = new AttackState(player, brain),
            };

            SetState<PatrolState>();
        }

        public void SetState<T>() where T : IEnemyState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(T)];
            _currentState.Enter();
        }

        public void Tick()
        {
            Debug.Log(_enemy.IsOnAnimation);

           

            var distance = Vector3.Distance(_player.transform.position, _enemy.transform.position);

            Debug.Log(distance);
            
            if (distance < _brain.Attckrange)
                SetState<AttackState>();
            
            if (_enemy.IsOnAnimation)
            {
                _currentState?.Tick();
                return;
            }

            if (distance > _brain.Attckrange)
                SetState<ChaseState>();

            if (distance > _brain.ChaseRange)
                SetState<PatrolState>();

            _currentState?.Tick();
        }
    }
}