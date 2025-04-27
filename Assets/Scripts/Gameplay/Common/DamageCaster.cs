using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class DamageCaster : MonoBehaviour
    {
        [Inject] private readonly DamageComponent _damageComponent;

        [Header("Cast Settings")] [SerializeField]
        private Transform sourceObject;

        [SerializeField] private float radius = 1f;

        [Header("Damage Settings")] [SerializeField]
        private LayerMask layerMask;

        private bool _shouldCast = false;

        private void OnEnable()
        {
            _shouldCast = false;
        }

        void Update()
        {
            if (_shouldCast && sourceObject != null)
                if (DoSingleSphereHit(sourceObject.position))
                    _shouldCast = false;
        }

        bool DoSingleSphereHit(Vector3 origin)
        {
            if (Physics.CheckSphere(origin, radius, layerMask))
            {
                var hitCollider = Physics.OverlapSphere(origin, radius, layerMask);
                if (hitCollider.Length > 0)
                {
                    var damageable = hitCollider[0].GetComponentInParent<IDamageable>();
                    if (damageable != null)
                    {
                        damageable.TakeDamage(_damageComponent.Damage);
                        return true;
                    }
                }
            }

            return false;
        }

        public void EnebleDamageCast(int shouldCast) => _shouldCast = shouldCast > 0;

        void OnDrawGizmos()
        {
            if (sourceObject == null) return;

            if (_shouldCast)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(sourceObject.position, radius);
            }
        }
    }
}