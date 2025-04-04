using System;
using Gameplay.Common;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private LootExplosionComponent _loot;
        [SerializeField] private HealthComponent _healthComponent;
        [Inject] private Player _player;

        private void OnEnable()
        {
            _healthComponent.DeSpawn += _loot.SpawnLoot;
        }
    }
}