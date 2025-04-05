using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class EnemyBrain : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _movePointRange;
        [SerializeField] private float _sightRange;
        [SerializeField] private float _attackRange;

        private GameObject _target;

        public bool IsMoving { get; private set; }
        public bool IsMovePointSet { get; private set; }
        private Vector3 _destination;

        private float _fireRate;
        public bool IsAttacking { get; private set; }

        public bool PlayerInSightRange { get; private set; }
        public bool PlayerInAttackRange { get; private set; }

        private void OnEnable()
        {
            _destination = SearchMovePoint();
            IsMovePointSet = true;
        }

        private void Update()
        {
            PlayerInSightRange = Vector3.Distance(_target.transform.position, transform.position) < _sightRange;
            PlayerInAttackRange = Vector3.Distance(_target.transform.position, transform.position) < _attackRange;

            if (PlayerInSightRange && PlayerInAttackRange) AttackingTarget();
            if (PlayerInSightRange && !PlayerInAttackRange) ChaseTarget();
            if (!PlayerInSightRange && !PlayerInAttackRange) Patroling();

            _agent.SetDestination(_destination);
        }

        public void Patroling()
        {
            _agent.speed = 3;
            if (!IsMovePointSet)
            {
                _destination = SearchMovePoint();
                IsMovePointSet = true;
            }

            var dis = Vector3.Distance(transform.position, _destination);

            if (dis < 1)
                IsMovePointSet = false;
        }

        private Vector3 SearchMovePoint()
        {
            var randomZ = Random.Range(0, _movePointRange);
            var randomX = Random.Range(0, _movePointRange);
            return new Vector3(randomX, 0, randomZ);
        }

        public void ChaseTarget()
        {
            _agent.speed = 6;

            _destination = _target.transform.position;
        }

        public void AttackingTarget()
        {
            _destination = transform.position;

            Vector3 lookAtPosition = _target.transform.position;
            lookAtPosition.y = transform.position.y;
            transform.LookAt(lookAtPosition);
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }
    }
}