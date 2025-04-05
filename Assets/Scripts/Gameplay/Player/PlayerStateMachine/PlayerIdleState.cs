using System.Collections;
using UnityEngine;

namespace Gameplay
{
    public class PlayerIdleState : IPlayerState
    {
        private readonly PlayerStateMachine _stateMachine;
        private readonly Player _player;
        private EnemyManager _enemiesManager;

        public PlayerIdleState(PlayerStateMachine stateMachine, Player player, EnemyManager enemiesManager)
        {
            _stateMachine = stateMachine;
            _player = player;
            _enemiesManager = enemiesManager;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Update()
        {
            if (_player.GetVelocity() != Vector3.zero)
                _stateMachine.SetState<PlayerMoveState>();

            /*if (_enemiesManager.HasEnemyInShootingRange(_player.GetWeaponFirerange()))
            {
                _stateMachine.SetState<PlayerFireState>();
            }*/
        }
    }
}