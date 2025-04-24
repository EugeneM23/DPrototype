using Modules;
using UnityEngine;

namespace Gameplay
{
    public class SphereDamageCaster : MonoBehaviour
    {
        [Header("Cast Settings")] public bool shouldCast = false;
        public Transform sourceObject;
        public float radius = 1f;

        [Header("Damage Settings")] public int damageAmount = 10;
        public LayerMask layerMask;

        void Update()
        {
            // Проверяем, если каст активен и не завершён, то выполняем
            if (shouldCast && sourceObject != null)
            {
                if (DoSingleSphereHit(sourceObject.position))
                {
                    shouldCast = false;
                }
            }
        }

        bool DoSingleSphereHit(Vector3 origin)
        {
            // Проверяем, есть ли объекты в радиусе с использованием CheckSphere
            if (Physics.CheckSphere(origin, radius, layerMask))
            {
                // Получаем первый коллайдер, который попадает в сферу
                var hitCollider = Physics.OverlapSphere(origin, radius, layerMask);
                if (hitCollider.Length > 0)
                {
                    var damageable = hitCollider[0].GetComponentInParent<IDamageable>();
                    if (damageable != null)
                    {
                        damageable.TakeDamage(damageAmount); // Наносим урон
                        return true; // Возвращаем true, чтобы каст завершился
                    }
                }
            }

            return false; // Если не попадём, возвращаем false
        }

        void OnDrawGizmos()
        {
            if (sourceObject == null) return;

            if (shouldCast)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(sourceObject.position, radius);
            }
        }
    }
}