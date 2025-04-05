using System.Collections.Generic;
using Gameplay.Common;
using Modules.PrefabPool;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyManager : IInitializable
    {
        private readonly GameObject[] _enemiesToSpawn;
        private readonly PrefabPool _prefabPool;

        private List<GameObject> _activeEnemies = new List<GameObject>();

        public EnemyManager(GameObject[] enemiesToSpawn,  PrefabPool prefabPool)
        {
            _enemiesToSpawn = enemiesToSpawn;
            _prefabPool = prefabPool;
        }

        public void Initialize()
        {
            for (int i = 0; i < 10; i++)
            {
                SpawnEnemy(_enemiesToSpawn[0]);
            }
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

        private GameObject SpawnEnemy(GameObject enemyPrefab)
        {
            Enemy enemy = _prefabPool.Spawn<Enemy>(enemyPrefab);
            enemy.GetComponent<HealthComponent>().DeSpawn += RemoveEnemy;
            AddEnemy(enemy.gameObject);

            Vector3 reand = Random.insideUnitSphere * 10;
            enemy.transform.position = reand;
            return enemy.gameObject;
        }

        private void AddEnemy(GameObject enemy) => _activeEnemies.Add(enemy);

        private void RemoveEnemy(GameObject enemy)
        {
            _activeEnemies.Remove(enemy);
            Debug.Log(_activeEnemies.Count);
        }
    }
}