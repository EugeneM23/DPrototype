using System.Collections.Generic;
using System.Linq;
using Gameplay.Common;
using Modules;

namespace Gameplay
{
    public class EnemyManager
    {
        private List<HealthComponentBase> _activeEnemies = new List<HealthComponentBase>();

        public bool TryGetTarget(float fireRange, out HealthComponentBase target, PlayerTransform player)
        {
            target = GetClosestEnemyInRange(fireRange, player);
            return target != null;
        }

        private HealthComponentBase GetClosestEnemyInRange(float range, PlayerTransform player)
        {
            float rangeSqr = range * range;

            return _activeEnemies
                .Where(enemy =>
                    (player.Transform.position - enemy.gameObject.transform.position).sqrMagnitude <= rangeSqr)
                .OrderBy(enemy => (player.Transform.position - enemy.gameObject.transform.position).sqrMagnitude)
                .FirstOrDefault();
        }

        public void AddEnemy(HealthComponentBase enemy) => _activeEnemies.Add(enemy);

        public void RemoveEnemy(HealthComponentBase enemy) => _activeEnemies.Remove(enemy);
    }
}