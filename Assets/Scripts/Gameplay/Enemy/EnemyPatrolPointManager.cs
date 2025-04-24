using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class EnemyPatrolPointManager
    {
        private PatrolPoints _patrolPoints;

        public EnemyPatrolPointManager(PatrolPoints patrolPoints)
        {
            _patrolPoints = patrolPoints;
        }

        public Vector3 GetNext()
        {
            int randomIndex = Random.Range(0, _patrolPoints.Points.Length);
            return _patrolPoints.Points[randomIndex].position;
        }
    }
}