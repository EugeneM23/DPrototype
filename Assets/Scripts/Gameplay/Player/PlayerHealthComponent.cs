using System;
using UnityEngine;

namespace Gameplay
{
    public class PlayerHealthComponent : MonoBehaviour, IDamagable
    {
        public event Action OnDeath;
        public event Action OnHit;
        public event Action<int> OnHealthChanged;
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
                OnDeath?.Invoke();
            }
        }
    }
}