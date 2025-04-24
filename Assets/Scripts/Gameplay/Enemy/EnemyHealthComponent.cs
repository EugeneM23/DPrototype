using System;
using Modules;
using UnityEngine;

namespace Gameplay
{
    public class EnemyHealthComponent : MonoBehaviour, IDamagable
    {
        public event Action<int> OnHealthChanged;

        public event Action<EnemyHealthComponent> OnDespawn;

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
            {
                OnDespawn?.Invoke(this);
            }
        }

        public void Reset()
        {
            _currentHealth = _healthMax;
            OnHealthChanged?.Invoke(_currentHealth);
        }
    }
}