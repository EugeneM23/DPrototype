using System.Collections.Generic;
using System.Linq;
using Modules;

namespace Gameplay
{
    public class EnemyManager
    {
        private List<HealthComponent> _activeEnemies = new List<HealthComponent>();

        public bool TryGetTarget(float fireRange, out HealthComponent target, PlayerTransform player)
        {
            target = GetClosestEnemyInRange(fireRange, player);
            return target != null;
        }

        private HealthComponent GetClosestEnemyInRange(float range, PlayerTransform player)
        {
            float rangeSqr = range * range;

            return _activeEnemies
                .Where(enemy =>
                    (player.Transform.position - enemy.gameObject.transform.position).sqrMagnitude <= rangeSqr)
                .OrderBy(enemy => (player.Transform.position - enemy.gameObject.transform.position).sqrMagnitude)
                .FirstOrDefault();
        }

        public void AddEnemy(HealthComponent enemy) => _activeEnemies.Add(enemy);

        public void RemoveEnemy(HealthComponent enemy) => _activeEnemies.Remove(enemy);
    }
}