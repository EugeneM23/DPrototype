using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class MeleeDamageComponent : MonoBehaviour
    {
        [Inject] private readonly EnemyDamage _damage;
        [Inject] private readonly Transform _player;
        [Inject] private readonly Transform _playerTransform;
        private int _attackDistance = 4;

        public void TakeDamage()
        {
            if (_attackDistance >= Vector3.Distance(transform.position, _playerTransform.position))
            {
                _player.GetComponent<HealthComponent>().TakeDamage(_damage.Damage);
            }
        }
    }
}