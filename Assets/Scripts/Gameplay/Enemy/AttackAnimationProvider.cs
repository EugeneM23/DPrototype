using Gameplay.BehComponents;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class AttackAnimationProvider : MonoBehaviour
    {
        [Inject]
        private EnemyConditions _conditions;

        public void FinishAttackAnimation() => _conditions.IsAttaking = false;

        public void StartAttackAnimation() => _conditions.IsAttaking = true;

        public void SetCondition(EnemyConditions conditions)
        {
            _conditions = conditions;
        }
    }
}