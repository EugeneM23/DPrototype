using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class HPBar : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;

        private int _maxHealth = 100;
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