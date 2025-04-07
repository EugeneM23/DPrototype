using UnityEngine;

namespace Gameplay
{
    public class EnemyPatrolPointManager : MonoBehaviour
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