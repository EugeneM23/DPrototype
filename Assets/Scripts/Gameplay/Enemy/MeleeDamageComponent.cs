using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class MeleeDamageComponent : MonoBehaviour
    {
        [Inject] private readonly EnemyDamage _damage;
        [Inject] private readonly PlayerTransform _playerTransform;
        private int _attackDistance = 4;

        public void TakeDamage()
        {
            if (_attackDistance >= Vector3.Distance(transform.position, _playerTransform.Transform.position))
            {
                _playerTransform.GetComponent<HealthComponent>().TakeDamage(_damage.Damage);
            }
        }
    }
}