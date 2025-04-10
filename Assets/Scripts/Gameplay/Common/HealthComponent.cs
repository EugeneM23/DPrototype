using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class HealthComponent : MonoBehaviour, IDamagable
    {
        public event Action OnDeath;

        [SerializeField] private int _health;

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
                OnDeath?.Invoke();
        }
    }
}