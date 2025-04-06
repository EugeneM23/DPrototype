using System;
using UnityEngine;

namespace Gameplay
{
    public class AttackState : IEnemyState
    {
        private readonly GameObject _player;
        private readonly EnemyBrain _enemy;

        public AttackState(GameObject player, EnemyBrain enemy)
        {
            _player = player;
            _enemy = enemy;
        }

        public void Tick()
        {
        }

        public void Exit()
        {
        }

        public void Enter()
        {
        }
    }
}