using System;
using Gameplay.Common;
using Modules.PrefabPool;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Enemy : MonoBehaviour, IDespawned
    {
        public event Action<GameObject> DeSpawn;

        [SerializeField] private LootExplosionComponent _loot;
        [SerializeField] private HealthComponent _healthComponent;
        private GameObject _target;

        private void OnEnable()
        {
            _healthComponent.DeSpawn += Despawn;
            _healthComponent.DeSpawn += _loot.SpawnLoot;
        }

        private void OnDisable()
        {
            _healthComponent.DeSpawn -= Despawn;
            _healthComponent.DeSpawn -= _loot.SpawnLoot;
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        private void Despawn(GameObject obj)
        {
            DeSpawn?.Invoke(gameObject);
        }

        public void Destroy()
        {
        }
    }
}