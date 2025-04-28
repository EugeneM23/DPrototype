using Gameplay.Modules;
using UnityEngine;

namespace NewEnemy
{
    public interface IEnemySpawner
    {
        public HealthComponentBase Create(Vector3 position);
    }
}