using System;
using UnityEngine;

namespace Gameplay
{
    public class ChaseState : IEnemyState
    {
        private readonly GameObject _player;
        private readonly EnemyBrain _enemy;

        public ChaseState(GameObject player, EnemyBrain enemy)
        {
            _player = player;
            _enemy = enemy;
        }

        public void Tick()
        {
            _enemy.SetDestination(_player.transform.position);
        }

        public void Enter()
        {
            _enemy.SetSpeed(5);
            
            _enemy.GetComponent<Enemy>().IsRuning = true;
        }

        public void Exit()
        {
            _enemy.GetComponent<Enemy>().IsRuning = false;
        }
    }
}