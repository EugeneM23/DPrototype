using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay
{
    public class PlayerHealtBar : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [Inject] private readonly int _maxHealth;

        private int _currentHealth;

        private void Start()
        {
            _healthSlider.maxValue = _maxHealth;
            _currentHealth = _maxHealth;
            _healthSlider.value = _currentHealth;
        }

        public void UpdatePlayerHealth(int health)
        {
            _healthSlider.value = health;
        }
    }
}