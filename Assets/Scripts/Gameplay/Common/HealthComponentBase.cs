using System;
using Modules;
using UnityEngine;

namespace Gameplay.Common
{
    public  class HealthComponentBase : MonoBehaviour, IDamageable
    {
        public event Action<int> OnHealthChanged;
        public event Action<HealthComponentBase> OnDespawn;
        public event Action OnHit;

        [SerializeField] protected int _healthMax = 100;
        protected int _currentHealth;

        protected virtual void Start()
        {
            _currentHealth = _healthMax;
        }

        public virtual void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            OnHealthChanged?.Invoke(_currentHealth);
            OnHit?.Invoke();

            if (_currentHealth <= 0)
            {
                OnDespawn?.Invoke(this);
            }
        }

        public virtual void Reset()
        {
            _currentHealth = _healthMax;
            OnHealthChanged?.Invoke(_currentHealth);
        }
    }
}