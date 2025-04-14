using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

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

    public class PlayerDeathObserver : IInitializable
    {
        private readonly PlayerHealthComponent _playerHealth;

        public PlayerDeathObserver(PlayerHealthComponent playerHealth)
        {
            _playerHealth = playerHealth;
        }

        public void Initialize()
        {
            _playerHealth.OnDeath += Death;
        }

        private void Death()
        {
            SceneManager.LoadScene("L_Base");
        }
    }
}