using System;
using Gameplay;

namespace Modules
{
    public interface IHealthComponent
    {
        public event Action<int> OnHealthChanged;
        public event Action<EnemyHealthComponent> OnDespawn;
        public event Action OnHit;
        
        public void Reset();
    }
}