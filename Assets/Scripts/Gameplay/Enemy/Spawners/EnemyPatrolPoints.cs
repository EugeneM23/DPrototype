using UnityEngine;

namespace Gameplay
{
    public class EnemyPatrolPoints : MonoBehaviour
    {
        [SerializeField] private Transform[] _patrolPoints;

        public Transform[] Points => _patrolPoints;
    }
}