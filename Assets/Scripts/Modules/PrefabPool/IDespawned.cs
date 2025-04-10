using System;
using UnityEngine;

namespace Modules.PrefabPool
{
    public interface IDespawned
    {
        public event Action DeSpawn;
        
        public void Destroy(GameObject gameObject);
    }
}