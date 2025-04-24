using System.Collections.Generic;
using System.Linq;
using Modules;

namespace Gameplay
{
    public class EnemyManager
    {
        private List<EnemyHealthComponent> _activeEnemies = new List<EnemyHealthComponent>();

        public bool TryGetTarget(float fireRange, out EnemyHealthComponent target, PlayerTransform player)
        {
            target = GetClosestEnemyInRange(fireRange, player);
            return target != null;
        }

        private EnemyHealthComponent GetClosestEnemyInRange(float range, PlayerTransform player)
        {
            float rangeSqr = range * range;

            return _activeEnemies
                .Where(enemy =>
                    (player.Transform.position - enemy.gameObject.transform.position).sqrMagnitude <= rangeSqr)
                .OrderBy(enemy => (player.Transform.position - enemy.gameObject.transform.position).sqrMagnitude)
                .FirstOrDefault();
        }

        public void AddEnemy(EnemyHealthComponent enemy) => _activeEnemies.Add(enemy);

        public void RemoveEnemy(EnemyHealthComponent enemy) => _activeEnemies.Remove(enemy);
    }
}