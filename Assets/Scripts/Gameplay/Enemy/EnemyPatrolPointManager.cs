using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    [Serializable]
    public class EnemyPatrolPointManager
    {
        private Transform[] _patrolPoints;

        public Vector3 GetNext()
        {
            int randomIndex = Random.Range(0, _patrolPoints.Length);
            return _patrolPoints[randomIndex].position;
        }

        public void SetPatrolPoints(Transform[] patrolPoints)
        {
            _patrolPoints = patrolPoints;
        }
    }
}