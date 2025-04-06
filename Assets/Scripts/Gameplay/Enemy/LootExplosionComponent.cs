using UnityEngine;

namespace Gameplay
{
    public class LootExplosionComponent : MonoBehaviour
    {
        [SerializeField] private GameObject[] _loot;

        public void SpawnLoot(GameObject obj)
        {
            foreach (var item in _loot)
            {
                Vector3 pos = Random.insideUnitSphere * 1;
                var asd = Instantiate(item, obj.transform.position + pos, Quaternion.identity);
                asd.GetComponent<Rigidbody>().linearVelocity = (Vector3.up + pos) * Random.Range(1f, 10f);
                asd.GetComponent<Rigidbody>().angularVelocity = (Vector3.up + pos) * Random.Range(1f, 10f);
            }
        }
    }
}