using System.Collections;
using UnityEngine;

namespace Gameplay
{
    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _lootPrefabs;

        private void OnEnable()
        {
            StartCoroutine(nameof(SpawnRoutine));
        }

        private IEnumerator SpawnRoutine()
        {
            foreach (var item in _lootPrefabs)
            {
                Instantiate(item, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}