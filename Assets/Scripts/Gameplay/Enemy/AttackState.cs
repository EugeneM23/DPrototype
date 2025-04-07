using System;
using UnityEngine;

namespace Gameplay
{
    public class AttackState : IEnemyState
    {
        private readonly GameObject _player;
        private readonly Enemy _enemy;

        public AttackState(GameObject player, Enemy enemy)
        {
            _player = player;
            _enemy = enemy;
        }

        public void Tick()
        {
            if (_enemy.IsOnAnimation)
                return;

            Vector3 direction = _player.transform.position - _enemy.transform.position;
            direction.y = 0;

            if (direction == Vector3.zero) return;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            _enemy.transform.rotation =
                Quaternion.Slerp(_enemy.transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        public void Enter()
        {
            _enemy.GetComponent<Enemy>().IsAttaking = true;
        }

        public void Exit()
        {
            _enemy.GetComponent<Enemy>().IsAttaking = false;
        }
    }
}