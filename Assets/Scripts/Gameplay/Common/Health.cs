using Gameplay.Modules;

namespace Player
{
    public class Health : IHealth
    {
        public int MaxHealth { get; }

        public Health(int maxHealth)
        {
            MaxHealth = maxHealth;
        }
    }
}