using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay
{
    public class PlayerDeathObserver : IInitializable
    {
        private readonly HealthComponent _health;

        public PlayerDeathObserver(HealthComponent health)
        {
            _health = health;
        }

        public void Initialize()
        {
            _health.OnDeath += Death;
        }

        private void Death()
        {
            SceneManager.LoadScene("L_Base");
        }
    }
}