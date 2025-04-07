using UnityEngine;

namespace Gameplay
{
    public class ChaseState : IEnemyState
    {
        private readonly GameObject _player;
        private readonly Enemy _enemy;
        private readonly EnemyStateMachine _stateMachine;

        public ChaseState(GameObject player, Enemy enemy, EnemyStateMachine stateMachine)
        {
            _player = player;
            _enemy = enemy;
            _stateMachine = stateMachine;
        }

        public void Tick() => _enemy.SetDestination(_player.transform.position);

        public void Enter()
        {
            _enemy.SetSpeed(8);
            _stateMachine.IsRuning = true;
        }

        public void Exit() => _stateMachine.IsRuning = false;
    }
}