using System;
using UnityEngine;

namespace Gameplay
{
    public class HealthComponent : MonoBehaviour, IDamagable
    {
        public event Action OnDeath;
        [SerializeField] private GameObject _deathEffect;

        [SerializeField] private int _health;

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                GameObject go = Instantiate(_deathEffect);
                go.transform.position = transform.position + new Vector3(0, 1, 0);
                OnDeath?.Invoke();
            }
        }
    }
}