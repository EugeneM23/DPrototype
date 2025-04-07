using Gameplay.Common;
using UnityEngine;

namespace Gameplay
{
    public class EnemyHealthController : MonoBehaviour
    {
        [SerializeField] private LootExplosionComponent _loot;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private Enemy _enemy;

        private void OnEnable()
        {
            _healthComponent.DeSpawn += _enemy.Despawn;
            _healthComponent.DeSpawn += _loot.SpawnLoot;
        }

        private void OnDisable()
        {
            _healthComponent.DeSpawn -= _enemy.Despawn;
            _healthComponent.DeSpawn -= _loot.SpawnLoot;
        }
    }
}