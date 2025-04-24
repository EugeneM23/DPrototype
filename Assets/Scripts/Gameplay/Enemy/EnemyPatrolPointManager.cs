using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class EnemyPatrolPointManager
    {
        private EnemyPatrolPoints _enemyPatrolPoints;

        public EnemyPatrolPointManager(EnemyPatrolPoints enemyPatrolPoints)
        {
            _enemyPatrolPoints = enemyPatrolPoints;
        }

        public Vector3 GetNext()
        {
            int randomIndex = Random.Range(0, _enemyPatrolPoints.Points.Length);
            return _enemyPatrolPoints.Points[randomIndex].position;
        }
    }
}