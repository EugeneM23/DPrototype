using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Gameplay
{
    internal class PatrolState : IEnemyState
    {
        private readonly EnemyBrain _enemy;

        private Vector3 _currentDestination;
        private float timer;
        private float wanderTimer = 5;

        public PatrolState(EnemyBrain enemy)
        {
            _enemy = enemy;
        }

        public void Tick()
        {
            _currentDestination = NextDestination();
            _enemy.SetDestination(_currentDestination);

            if (_enemy.GetVelocity() < 1)
            {
                _enemy.GetComponent<Enemy>().IsAidling = true;
                _enemy.GetComponent<Enemy>().IsWalking = false;
            }
            else
            {
                _enemy.GetComponent<Enemy>().IsAidling = false;
                _enemy.GetComponent<Enemy>().IsWalking = true;
            }
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
            _enemy.SetDestination(_currentDestination);

            _enemy.GetComponent<Enemy>().IsWalking = true;
        }

        public void Exit()
        {
            _enemy.GetComponent<Enemy>().IsWalking = false;
            _enemy.GetComponent<Enemy>().IsAidling = false;
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