using System;
using UnityEngine;

namespace Gameplay
{
    public class AttackState : IEnemyState
    {
        private readonly GameObject _player;
        private readonly Enemy _enemy;
        private readonly EnemyStateMachine _stateMachine;

        public AttackState(GameObject player, Enemy enemy, EnemyStateMachine stateMachine)
        {
            _player = player;
            _enemy = enemy;
            _stateMachine = stateMachine;
        }

        public void Tick()
        {
            _enemy.AgentStop();
            Vector3 direction = _player.transform.position - _enemy.transform.position;
            direction.y = 0;

            if (direction == Vector3.zero) return;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            _enemy.transform.rotation =
                Quaternion.Slerp(_enemy.transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        public void Enter()
        {
            _enemy.AgentStop();

            _stateMachine.IsAttaking = true;
            //_stateMachine.IsOnAnimation = true;
        }

        public void Exit()
        {
            _enemy.AgentStarg();
            _stateMachine.IsAttaking = false;
        }
    }
}