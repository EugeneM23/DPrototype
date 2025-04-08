using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class EnemyPatrolPointManager
    {
        private Transform[] _patrolPoints;

        public EnemyPatrolPointManager(Transform[] patrolPoints)
        {
            _patrolPoints = patrolPoints;
        }

        public Vector3 GetNext()
        {
            int randomIndex = Random.Range(0, _patrolPoints.Length);
            return _patrolPoints[randomIndex].position;
        }
    }
}