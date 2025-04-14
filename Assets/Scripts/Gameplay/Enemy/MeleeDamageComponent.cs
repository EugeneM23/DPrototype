using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class MeleeDamageComponent : MonoBehaviour
    {
        [Inject] private readonly EnemyDamage _damage;
        [Inject] private readonly Player _player;
        private int _attackDistance = 4;

        public void TakeDamage()
        {
            if (_attackDistance >= Vector3.Distance(transform.position, _player.transform.position))
            {
                _player.TakeDamage(_damage.Damage);
            }
        }
    }
}