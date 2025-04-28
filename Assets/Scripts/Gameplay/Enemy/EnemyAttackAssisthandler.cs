using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyAttackAssisthandler : MonoBehaviour
    {
        [Inject] private readonly EnemyAttackAssistComponent _rotationComponent;

        private bool _isAssistEnable;

        private void OnEnable()
        {
            _isAssistEnable = false;
        }

        //Called by an event in animation
        private void AimAssistOn() => _isAssistEnable = true;
        
        //Called by an event in animation
        private void AimAssistOff() => _isAssistEnable = false;

        private void Update()
        {
            if (_isAssistEnable)
                _rotationComponent.RotateToTarget();
        }
    }
}