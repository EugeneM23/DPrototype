using System;
using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay.Modules
{
    public class HealthComponentBase : MonoBehaviour, IDamageable
    {
        public event Action<int> OnHealthChanged;
        public event Action<HealthComponentBase> OnDespawn;
        public event Action OnHit;

        [Inject] private IHealth _health;

        protected int _currentHealth;

        protected virtual void Start()
        {
            _currentHealth = _health.MaxHealth;
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
            _currentHealth = _health.MaxHealth;
            OnHealthChanged?.Invoke(_currentHealth);
        }
    }
}