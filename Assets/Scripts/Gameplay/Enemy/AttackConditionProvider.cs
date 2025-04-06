using UnityEngine;

namespace Gameplay
{
    public class AttackConditionProvider : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;

        public void FinishAnimation()
        {
            _enemy.IsOnAnimation = false;
        }

        public void StartAnimation()
        {
            _enemy.IsOnAnimation = true;
        }
    }
}