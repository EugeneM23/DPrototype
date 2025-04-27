using Gameplay.Modules;
using UnityEngine;
using DamageNumbersPro;

namespace Gameplay.Common
{
    public class DamageNumberSpawner : MonoBehaviour
    {
        public DamageNumber popupPrefab;

        public Transform target;

        private void OnEnable()
        {
            GetComponent<HealthComponentBase>().OnTakeDamaged += SpawnPopup;
        }

        private void OnDisable()
        {
            GetComponent<HealthComponentBase>().OnTakeDamaged -= SpawnPopup;
        }

        public void SpawnPopup(int damage)
        {
            DamageNumber newPopup = popupPrefab.Spawn(target.position + new Vector3(0, 3, 0), damage);
        }
    }
}