using UnityEngine;

namespace Gameplay
{
    public interface IBulletSpawner
    {
        public Bullet Create(Vector3 position, Quaternion rotation);
    }
}