using Gameplay.Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemySpawnLootInitializer : MonoBehaviour
    {
        [SerializeField] private LootSpawner _spawnLoot;
        [Inject] private readonly HealthComponentBase _healthComponent;

        private void OnEnable()
        {
            _healthComponent.OnDespawn += InitSpawnLoot;
        }

        private void InitSpawnLoot(HealthComponentBase obj)
        {
            Instantiate(_spawnLoot, transform.position, Quaternion.identity);
        }
    }
}