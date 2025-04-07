using UnityEngine;

namespace Gameplay
{
    public class ChaseState : EnemyBaseState
    {
        public ChaseState(GameObject player, Enemy enemy, EnemyStateMachine stateMachine) : base(player, enemy,
            stateMachine)
        {
            _player = player;
            _stateMachine = stateMachine;
            _enemy = enemy;
        }

        public override void Tick()
        {
            if (_stateMachine.PlayerInAttackRange())
            {
                _stateMachine.SetState<AttackState>();
                return;
            }

            if (!_stateMachine.PlayerInChaseRange())
            {
                _stateMachine.SetState<PatrolState>();
                return;
            }

            _enemy.SetDestination(_player.transform.position);
        }

        public override void Enter()
        {
            _enemy.SetSpeed(8f);
            _stateMachine.IsRuning = true;
        }

        public override void Exit()
        {
            _enemy.SetSpeed(2.8f);

            _stateMachine.IsRuning = false;
        }
    }
}