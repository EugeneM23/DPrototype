using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyManager : ITickable
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
            float rangeSqr = range * range;

            return _activeEnemies
                .Where(enemy => (player.position - enemy.transform.position).sqrMagnitude <= rangeSqr)
                .OrderBy(enemy => (player.position - enemy.transform.position).sqrMagnitude)
                .FirstOrDefault();
        }

        public void AddEnemy(GameObject enemy) => _activeEnemies.Add(enemy);

        public void RemoveEnemy(GameObject enemy) => _activeEnemies.Remove(enemy);
        public void Tick()
        {
            Debug.Log(_activeEnemies.Count);
        }
    }
}