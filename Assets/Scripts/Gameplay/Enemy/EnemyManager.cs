using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyManager
    {
        private List<GameObject> _activeEnemies = new List<GameObject>();

        public int Count => _activeEnemies.Count;

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

        public void AddEnemy(GameObject enemy) => _activeEnemies.Add(enemy);

        public void RemoveEnemy(GameObject enemy) => _activeEnemies.Remove(enemy);
    }
}