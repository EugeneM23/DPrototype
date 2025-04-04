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
                var asd = Instantiate(item, obj.transform.position, Quaternion.identity);
                asd.GetComponent<Rigidbody>().linearVelocity = Vector3.up * Random.Range(1f, 10f);
            }
        }
    }
}