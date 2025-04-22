using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyManager
    {
        private List<GameObject> _activeEnemies = new List<GameObject>();
        public int Count => _activeEnemies.Count;

        public bool TryGetTarget(float fireRange, out GameObject target, PlayerTransform player)
        {
            target = GetClosestEnemyInRange(fireRange, player);
            return target != null;
        }

        private GameObject GetClosestEnemyInRange(float range, PlayerTransform player)
        {
            float rangeSqr = range * range;

            return _activeEnemies
                .Where(enemy => (player.Player.position - enemy.transform.position).sqrMagnitude <= rangeSqr)
                .OrderBy(enemy => (player.Player.position - enemy.transform.position).sqrMagnitude)
                .FirstOrDefault();
        }

        public void AddEnemy(GameObject enemy) => _activeEnemies.Add(enemy);

        public void RemoveEnemy(GameObject enemy) => _activeEnemies.Remove(enemy);

        public List<GameObject> GetAllEnemies()
        {
            return _activeEnemies;
        }
    }
}