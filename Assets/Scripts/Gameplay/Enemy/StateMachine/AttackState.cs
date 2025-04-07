using System;
using UnityEngine;

namespace Gameplay
{
    public class AttackState : EnemyBaseState
    {

        public AttackState(GameObject player, Enemy enemy, EnemyStateMachine stateMachine) : base(player, enemy,
            stateMachine)
        {
        }

        public override void Tick()
        {
            _enemy._agent.isStopped = true;
            if (!_stateMachine.PlayerInAttackRange())
            {
                _enemy._agent.isStopped = false;
                _stateMachine.SetState<ChaseState>();
            }

            if (_stateMachine.IsOnAnimation) return;
            
            Vector3 direction = _player.transform.position - _enemy.transform.position;
            direction.y = 0;

            if (direction == Vector3.zero) return;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            _enemy.transform.rotation =
                Quaternion.Slerp(_enemy.transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        public override void Enter()
        {
            _stateMachine.IsAttaking = true;
            _enemy._agent.isStopped = true;
        }

        public override void Exit()
        {
            _stateMachine.IsAttaking = false;
            _enemy._agent.isStopped = false;
        }
    }
}