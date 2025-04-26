using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyAttackAssisthandler : MonoBehaviour
    {
        [Inject] private readonly EnemyAttackAssistComponent _rotationComponent;
        
        private bool IsAssistEnable;

        private void AimAssistOn() => IsAssistEnable = true;

        private void AimAssistOff() => IsAssistEnable = false;

        private void Update()
        {
            if (IsAssistEnable)
                _rotationComponent.RotateToTarget();
        }
    }
}