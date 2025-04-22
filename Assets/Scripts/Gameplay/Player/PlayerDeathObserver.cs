using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay
{
    public class PlayerDeathObserver : IInitializable
    {
        private readonly PlayerHealthComponent _playerHealth;

        public PlayerDeathObserver(PlayerHealthComponent playerHealth)
        {
            _playerHealth = playerHealth;
        }

        public void Initialize()
        {
            _playerHealth.OnDeath += Death;
        }

        private void Death()
        {
            SceneManager.LoadScene("L_Base");
        }
    }
}