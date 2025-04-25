using Gameplay.Modules;
using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay
{
    public class PlayerDeathController : IInitializable
    {
        private readonly HealthComponentBase _playerHealthComponent;

        public PlayerDeathController(HealthComponentBase playerHealthComponent)
        {
            _playerHealthComponent = playerHealthComponent;
        }

        public void Initialize()
        {
            _playerHealthComponent.OnDespawn += Despaw;
        }

        private void Despaw(HealthComponentBase obj)
        {
            SceneManager.LoadScene("L_Base");
        }
    }
}