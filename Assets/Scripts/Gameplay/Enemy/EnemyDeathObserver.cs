using UnityEngine;

namespace Gameplay
{
    /*public class EnemyDeathObserver : DeathObserver
    {
        protected readonly EnemyTransform _enemy;
        private EnemyManager _manager;

        public EnemyDeathObserver(HealthComponent health, EnemyTransform enemy, EnemyManager manager) : base(health)
        {
            _enemy = enemy;
            _manager = manager;
        }

        public override void Death(HealthComponent obj)
        {
            _manager.RemoveEnemy(obj);
            Object.Destroy(_enemy.gameObject);
        }
    }*/
}