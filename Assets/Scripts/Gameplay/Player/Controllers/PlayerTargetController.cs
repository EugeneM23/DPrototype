using System.ComponentModel;
using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerTargetController : ITickable
    {
        private readonly PlayerTransform _playerTransform;
        private readonly Player _player;
        private readonly Weapon _weapon;
        private readonly DiContainer _container;
        private EnemyManager _enemyManager;

        public PlayerTargetController(Player player, PlayerTransform playerTransform, DiContainer container)
        {
            _player = player;
            _playerTransform = playerTransform;
            _container = container;

            EnemyManager manager = _container.TryResolve<EnemyManager>();

            if (manager != null)
                SetEnemyManager(manager);
        }

        public void Tick()
        {
            if (_enemyManager == null) return;

            if (_enemyManager.TryGetTarget(20, out EnemyHealthComponent target, _playerTransform))
                _player.SetTarget(target);
            else
                _player.SetTarget(null);
        }

        public void SetEnemyManager(EnemyManager manager)
        {
            _enemyManager = manager;
        }
    }
}