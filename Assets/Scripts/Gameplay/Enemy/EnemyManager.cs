using System.Collections.Generic;
using Gameplay.Common;
using Modules.PrefabPool;
using UnityEngine;

namespace Gameplay
{
    public class EnemyManager
    {
        private readonly PrefabPool _prefabPool;

        private List<GameObject> _activeEnemies = new List<GameObject>();

        public EnemyManager(PrefabPool prefabPool)
        {
            _prefabPool = prefabPool;
        }

        public bool TryGetTarget(float fireRange, out GameObject target, Transform player)
        {
            target = GetClosestEnemyInRange(fireRange, player);
            return target != null;
        }

        private GameObject GetClosestEnemyInRange(float range, Transform player)
        {
            GameObject closestEnemy = null;
            float minDistanceSqr = range * range;

            foreach (GameObject enemy in _activeEnemies)
            {
                if (enemy == null)
                    return null;

                float distanceSqr = (player.position - enemy.transform.position).sqrMagnitude;
                if (distanceSqr <= minDistanceSqr)
                {
                    minDistanceSqr = distanceSqr;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }

        public GameObject SpawnEnemy(GameObject enemyPrefab, Vector3 transformPosition)
        {
            HealthComponent enemy = _prefabPool.Spawn<HealthComponent>(enemyPrefab);
            enemy.DeSpawn += RemoveEnemy;
            enemy.transform.position = transformPosition;
            AddEnemy(enemy.gameObject);

            return enemy.gameObject;
        }

        private void AddEnemy(GameObject enemy) => _activeEnemies.Add(enemy);

        private void RemoveEnemy(GameObject enemy)
        {
            _activeEnemies.Remove(enemy);
        }
    }
}