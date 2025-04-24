using UnityEngine;

namespace Gameplay
{
    public class PatrolPoints : MonoBehaviour
    {
        [SerializeField] private Transform[] _patrolPoints;

        public Transform[] Points => _patrolPoints;
    }
}