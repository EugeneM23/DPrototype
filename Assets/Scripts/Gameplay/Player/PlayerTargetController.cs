using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerTargetController : ITickable
    {
        private readonly Player _player;
        private readonly EnemyManager _enemyManager;
        private readonly Weapon _weapon;

        public PlayerTargetController(Player player, EnemyManager enemyManager)
        {
            _player = player;
            _enemyManager = enemyManager;
            //_weapon = player.GetWeapon();
        }

        public void Tick()
        {
            if (_enemyManager.TryGetTarget(20, out GameObject target, _player.transform))
                _player.SetTarget(target);
            else
                _player.SetTarget(null);
        }
    }
}