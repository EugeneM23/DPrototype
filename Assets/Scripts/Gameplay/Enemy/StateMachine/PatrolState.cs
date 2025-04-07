using UnityEngine;

namespace Gameplay
{
    internal class PatrolState : EnemyBaseState
    {
        private Vector3 _currentDestination;
        private float timer;
        private float wanderTimer = 5;

        public PatrolState(GameObject player, Enemy enemy, EnemyStateMachine stateMachine) : base(player, enemy,
            stateMachine)
        {
        }

        public override void Tick()
        {
            if (_stateMachine.PlayerInChaseRange())
            {
                _stateMachine.SetState<ChaseState>();
                return;
            }

            if (_stateMachine.PlayerInAttackRange())
            {
                _stateMachine.SetState<AttackState>();
            }

            if (_enemy._agent.remainingDistance < 1f)
            {
                _currentDestination = GetNextPoint();
                _enemy.SetDestination(_currentDestination);
            }
        }

        public override void Enter()
        {
            _currentDestination = GetNextPoint();
            _enemy.SetDestination(_currentDestination);
            _stateMachine.IsWalking = true;
        }

        public override void Exit()
        {
            _stateMachine.IsWalking = false;
        }

        private Vector3 GetNextPoint()
        {
            return _enemy.GetComponent<EnemyPatrolPointManager>().GetNext();
        }
    }
}