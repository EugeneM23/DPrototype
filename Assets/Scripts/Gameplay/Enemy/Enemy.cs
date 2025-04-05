using System;
using Gameplay.Common;
using Modules.PrefabPool;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class Enemy : MonoBehaviour, IDespawned
    {
        public event Action<GameObject> DeSpawn;

        [SerializeField] private LootExplosionComponent _loot;
        [SerializeField] private HealthComponent _healthComponent;
        [Inject] private Player _player;

        private void OnEnable()
        {
            _healthComponent.DeSpawn += _loot.SpawnLoot;
        }

        public void Destroy()
        {
            Debug.Log("Destroy");
            DeSpawn?.Invoke(gameObject);
        }
    }
}