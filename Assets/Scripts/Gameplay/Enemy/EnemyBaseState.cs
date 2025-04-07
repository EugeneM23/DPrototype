using UnityEngine;

namespace Gameplay
{
    public abstract class EnemyBaseState
    {
        protected GameObject _player;
        protected Enemy _enemy;
        protected EnemyStateMachine _stateMachine;

        protected EnemyBaseState(GameObject player, Enemy enemy, EnemyStateMachine stateMachine)
        {
            _player = player;
            _enemy = enemy;
            _stateMachine = stateMachine;
        }

        public abstract void Tick();
        public abstract void Exit();
        public abstract void Enter();
    }
}