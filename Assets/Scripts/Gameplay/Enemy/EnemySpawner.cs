using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Transform[] _patrolPoints;
        private EnemyManager _manager;
        private Player _player;

        [Inject]
        public void Construct(EnemyManager manager, Player player)
        {
            _manager = manager;
            _player = player;
        }

        private void Start()
        {
            GameObject enemy = _manager.SpawnEnemy(_enemyPrefab.gameObject, transform.position);
            enemy.GetComponent<Enemy>().SetTarget(_player.gameObject);
            enemy.GetComponent<Enemy>().SetSpawnPoints(_patrolPoints);
        }
    }
}