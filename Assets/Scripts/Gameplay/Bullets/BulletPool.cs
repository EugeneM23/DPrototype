using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletPool : MemoryPool<Vector3, Quaternion, Bullet>, IBulletSpawner
    {
        public Bullet Create(Vector3 position, Quaternion rotation)
        {
            return Spawn(position, rotation);
        }

        protected override void Reinitialize(Vector3 position, Quaternion rotation, Bullet bullet)
        {
            bullet.SetPositionAndRotation(position, rotation);
        }

        protected override void OnSpawned(Bullet bullet)
        {
            base.OnSpawned(bullet);
            bullet.gameObject.SetActive(true);
            bullet.OnDispose += Despawn;
        }

        protected override void OnDespawned(Bullet bullet)
        {
            base.OnDespawned(bullet);
            bullet.gameObject.SetActive(false);
            bullet.OnDispose -= Despawn;
        }
    }

    public interface IBulletSpawner
    {
        public Bullet Create(Vector3 position, Quaternion rotation);
    }
}