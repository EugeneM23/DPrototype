using UnityEngine;
using DamageNumbersPro;

namespace Gameplay
{
    public class DamageNumberSpawner
    {
        private DamageNumber _popupPrefab;
        private Transform _target;

        public DamageNumberSpawner(DamageNumber popupPrefab, Transform target)
        {
            _popupPrefab = popupPrefab;
            _target = target;
        }

        public void SpawnPopup(int damage)
        {
            _popupPrefab.Spawn(_target.position + new Vector3(0, 3, 0), damage);
        }
    }
}