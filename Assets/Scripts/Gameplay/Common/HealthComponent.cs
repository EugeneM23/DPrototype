using System;
using Modules.PrefabPool;
using UnityEngine;

namespace Gameplay.Common
{
    public class HealthComponent : MonoBehaviour, IDamagable, IDespawned
    {
        public event Action<GameObject> DeSpawn;
        public void Destroy(GameObject gameObject)
        {
            
        }

        [SerializeField] private int _health;

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                DeSpawn?.Invoke(gameObject);
            }
        }
    }
}