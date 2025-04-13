using Zenject;

namespace Gameplay
{
    public class PlayerHealtController : IInitializable
    {
        private readonly PlayerHealthComponent _playerHealth;
        private PlayerHealthView _playerHealthView;

        public void Initialize()
        {
            _playerHealth.OnHealthChanged += _playerHealthView.UpdateHealth;
        }
    }

    internal class PlayerHealthView
    {
        public void UpdateHealth(int health)
        {
        }
    }
}