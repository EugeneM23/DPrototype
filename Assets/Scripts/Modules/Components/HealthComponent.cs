using System;
using UnityEngine;

namespace Modules
{
    public class HealthComponent : MonoBehaviour, IDamagable
    {
        public event Action<int> OnHealthChanged;
        public event Action<HealthComponent> OnDeath;
        public event Action OnHit;

        private int _currentHealth = 100;
        private int _healthMax = 100;

        private void Start()
        {
            _currentHealth = _healthMax;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            OnHealthChanged?.Invoke(_currentHealth);
            OnHit?.Invoke();

            if (_currentHealth <= 0)
                OnDeath?.Invoke(this);
        }

        public void Reset()
        {
            _currentHealth = _healthMax;
            OnHealthChanged?.Invoke(_currentHealth);
        }
    }
}