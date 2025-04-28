using System;
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

        private void AimAssistOn() => _isAssistEnable = true;

        private void AimAssistOff() => _isAssistEnable = false;

        private void Update()
        {
            if (_isAssistEnable)
                _rotationComponent.RotateToTarget();
        }
    }
}