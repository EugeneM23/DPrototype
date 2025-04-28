using System;
using Modules;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Modules
{
    public class HealthComponentBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private GameObject[] _deathEffectPrefab;
        public event Action<int> OnHealthChanged;
        public event Action<HealthComponentBase> OnDespawn;
        public event Action OnHit;
        public event Action<int> OnTakeDamaged;

        [Inject] private IHealth _health;

        protected int _currentHealth;
        private bool _isDaied;

        private void OnEnable()
        {
            _isDaied = false;
        }

        protected virtual void Start()
        {
            _currentHealth = _health.MaxHealth;
        }

        public virtual void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            OnHealthChanged?.Invoke(_currentHealth);
            OnHit?.Invoke();
            OnTakeDamaged?.Invoke(damage);

            if (_currentHealth <= 0)
            {
                if (_deathEffectPrefab != null && !_isDaied)
                {
                    _isDaied = true;
                    int randomIndex = Random.Range(0, _deathEffectPrefab.Length);
                    Vector3 forward = transform.forward;
                    forward.y = 0;
                    var rotation = Quaternion.LookRotation(forward);
                    Instantiate(_deathEffectPrefab[randomIndex], transform.position + new Vector3(0, 3, 0),
                        rotation * Quaternion.Euler(0, 90, 0));
                }

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