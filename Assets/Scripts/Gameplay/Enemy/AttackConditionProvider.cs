using Gameplay.BehComponents;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class AttackConditionProvider : MonoBehaviour
    {
         [SerializeField] private EnemyConditions _conditions;

        public void FinishAnimation() => _conditions.IsOnAnimation = false;

        public void StartAnimation() => _conditions.IsOnAnimation = true;
    }
}