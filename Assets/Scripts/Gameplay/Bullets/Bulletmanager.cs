using System.Collections.Generic;
using Modules.PrefabPool;
using UnityEngine;

namespace Gameplay
{
    public class Bulletmanager
    {
        private PrefabPool _prefabPoll;
        private List<GameObject> _activeObjects = new List<GameObject>();

        public Bulletmanager(PrefabPool prefabPoll)
        {
            _prefabPoll = prefabPoll;
        }

        private void RemoveBulletFromActivList(GameObject bullet)
        {
            _activeObjects.Remove(bullet);
            bullet.GetComponent<IDespawned>().DeSpawn -= RemoveBulletFromActivList;
        }

        public void SpawnBullet(BulletInfo info, Vector3 firePointPosition, Vector3 fireDirection)
        {
            Bullet bullet = _prefabPoll.Spawn<Bullet>(info.BulletPrefab);
            _activeObjects.Add(bullet.gameObject);

            bullet.GetComponent<IDespawned>().DeSpawn += RemoveBulletFromActivList;
            bullet.SetMoveDirection(fireDirection);
            bullet.SetPosition(firePointPosition);
            bullet.Construct(info.Damage, info.PhysicsLayer, info.BulletSpeed);
        }
    }
}