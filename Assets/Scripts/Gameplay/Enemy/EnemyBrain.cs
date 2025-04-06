using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class EnemyBrain : MonoBehaviour
    {
        [field: SerializeField] public float ChaseRange { get; private set; }
        [field: SerializeField] public float Attckrange { get; private set; }

        [SerializeField] private NavMeshAgent _agent;

        private GameObject _target;

        private Vector3 _destination;
        private float _fireRate;

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        public void SetDestination(Vector3 transformPosition)
        {
            _agent.SetDestination(transformPosition);
        }

        public void SetSpeed(float speed)
        {
            _agent.speed = speed;
        }

        public float GetVelocity()
        {
            return _agent.velocity.magnitude;
        }
    }
}