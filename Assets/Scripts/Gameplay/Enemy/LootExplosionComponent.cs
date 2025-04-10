using System;
using Gameplay.Common;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class LootExplosionComponent : MonoBehaviour
    {
        [SerializeField] private GameObject[] _loot;

        [Inject] private readonly HealthComponent _healthComponent;

        private void OnEnable() => _healthComponent.OnDeath += SpawnLoot;

        private void OnDisable() => _healthComponent.OnDeath -= SpawnLoot;

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