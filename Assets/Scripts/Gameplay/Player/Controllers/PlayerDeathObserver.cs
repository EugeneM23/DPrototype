using Modules;
using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay
{
    public class PlayerDeathObserver : IInitializable
    {
        private readonly PlayerHealthComponent _playerHealthComponent;

        public PlayerDeathObserver(PlayerHealthComponent playerHealthComponent)
        {
            _playerHealthComponent = playerHealthComponent;
        }

        public void Initialize()
        {
            _playerHealthComponent.OnDespawn += Despaw;
        }

        private void Despaw(PlayerHealthComponent obj)
        {
            SceneManager.LoadScene("L_Base");
        }
    }
}