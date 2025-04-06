using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    internal class PatrolState : IEnemyState
    {
        private readonly EnemyBrain _enemy;

        private Vector3 _currentDestination;
        private float timer;
        private float wanderTimer = 3;

        public PatrolState(EnemyBrain enemy)
        {
            _enemy = enemy;
        }

        public void Tick()
        {
            NextDestination();
            _enemy.SetDestination(_currentDestination);
        }

        private void NextDestination()
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                _currentDestination = GetRandomPointOnNavMesh(_enemy.transform.position, 20);

                timer = 0;
            }
        }

        public void Enter()
        {
            _enemy.SetSpeed(2);
            _enemy.SetDestination(_currentDestination);
        }

        public void Exit()
        {
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