using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class LootExplosionComponent : MonoBehaviour
    {
        [SerializeField] private GameObject[] _loot;

        [Inject] private readonly EnemyHealthComponent _enemyHealthComponent;

        private void OnEnable() => _enemyHealthComponent.OnDeath += SpawnLoot;

        private void OnDisable() => _enemyHealthComponent.OnDeath -= SpawnLoot;

        public void SpawnLoot()
        {
            foreach (var item in _loot)
            {
                Vector3 pos = Random.insideUnitSphere * 1;
                var asd = Instantiate(item, transform.position + pos, Quaternion.identity);
                asd.GetComponent<Rigidbody>().linearVelocity = (Vector3.up + pos) * Random.Range(1f, 10f);
                asd.GetComponent<Rigidbody>().angularVelocity = (Vector3.up + pos) * Random.Range(1f, 10f);
            }
        }
    }
}