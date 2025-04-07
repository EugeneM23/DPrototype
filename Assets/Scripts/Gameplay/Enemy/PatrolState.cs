using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Gameplay
{
    internal class PatrolState : IEnemyState
    {
        private readonly Enemy _enemy;
        private readonly EnemyStateMachine _stateMachine;

        private Vector3 _currentDestination;
        private float timer;
        private float wanderTimer = 5;

        public PatrolState(Enemy enemy, EnemyStateMachine stateMachine)
        {
            _enemy = enemy;
            _stateMachine = stateMachine;
        }

        public void Tick()
        {
            _currentDestination = NextDestination();
            _enemy.SetDestination(_currentDestination);

            /*if (_enemy.GetVelocity() < 1)
            {
                _stateMachine.IsAidling = true;
                _stateMachine.IsWalking = false;
            }
            else
            {
                _stateMachine.IsAidling = false;
                _stateMachine.IsWalking = true;
            }*/
        }

        private Vector3 NextDestination()
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                timer = 0;
                return GetRandomPointOnNavMesh(_enemy.transform.position, 20);
            }

            return _currentDestination;
        }

        public void Enter()
        {
            _enemy.SetSpeed(2);
            _currentDestination = NextDestination();

            _stateMachine.IsWalking = true;
        }

        public void Exit()
        {
            _stateMachine.IsWalking = false;
            _stateMachine.IsAidling = false;
        }

        Vector3 GetRandomPointOnNavMesh(Vector3 center, float radius)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 randomPos = center + Random.insideUnitSphere * radius;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPos, out hit, 2f, NavMesh.AllAreas))
                    return hit.position;
            }

            return center;
        }
    }
}