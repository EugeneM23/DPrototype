using UnityEngine;

namespace Gameplay
{
    public interface IEnemySpawner
    {
        public Enemy Create(Vector3 position);
    }
}