using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerTargetController : ITickable
    {
        private readonly PlayerTransform _playerTransform;
        private readonly Player _player;
        private readonly EnemyManager _enemyManager;
        private readonly Weapon _weapon;

        public PlayerTargetController(Player player, PlayerTransform playerTransform, EnemyManager enemyManager)
        {
            _player = player;
            _playerTransform = playerTransform;
            _enemyManager = enemyManager;
        }

        public void Tick()
        {
            if (_enemyManager.TryGetTarget(20, out GameObject target, _playerTransform))
                _player.SetTarget(target);
            else
                _player.SetTarget(null);
        }
    }
}