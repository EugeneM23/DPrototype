using System;
using System.Linq;
using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerTargetFinder : MonoBehaviour
    {
        [SerializeField] private float _refreshRate;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _radius;
        [SerializeField] private bool _shouldCast = true;

        [Inject] private Player _player;

        private Transform _target;
        private float _lastRefreshTime;

        private void Update()
        {
            if (_player.IsMoving)
            {
                _lastRefreshTime = 0;
                return;
            }

            _lastRefreshTime -= Time.deltaTime;
            _shouldCast = false;

            if (_lastRefreshTime <= 0)
            {
                _shouldCast = true;
                _lastRefreshTime = _refreshRate;
                DoSingleSphereHit(transform.position);
                
                _player.SetTarget(_target);
            }
        }

        private void DoSingleSphereHit(Vector3 origin)
        {
            if (Physics.CheckSphere(origin, _radius, _layerMask))
            {
                Collider[] hitCollider = Physics.OverlapSphere(origin, _radius, _layerMask);
                if (hitCollider.Length > 0)
                {
                    _target = FindNearestTarget(hitCollider).transform;
                    return;
                }
            }

            _target = null;
        }

        Collider FindNearestTarget(Collider[] targets)
        {
            if (targets == null || targets.Length == 0) return null;

            return targets
                .OrderBy(t => Vector3.Distance(transform.position, t.transform.position))
                .FirstOrDefault();
        }

        void OnDrawGizmos()
        {
            if (_shouldCast)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, _radius);
            }
        }
    }
}