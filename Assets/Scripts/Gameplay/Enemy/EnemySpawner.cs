using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

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

        private IEnumerator Start()
        {
            while (true)
            {
                GameObject enemy = _manager.SpawnEnemy(_enemyPrefab.gameObject, transform.position);
                enemy.GetComponent<Enemy>().SetTarget(_player.gameObject);
                enemy.GetComponent<Enemy>().SetSpawnPoints(_patrolPoints);
                int rand = Random.Range(0, 3);
                yield return new WaitForSeconds(rand);
            }
        }
    }
}