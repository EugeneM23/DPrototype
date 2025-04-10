using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Common
{
    public class HealthComponent : MonoBehaviour, IDamagable
    {
        [SerializeField] private int _health;
        
        public event Action OnDeath;


        public void TakeDamage(int damage)
        {
            Debug.Log(_health);
            _health -= damage;
            if (_health <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
}