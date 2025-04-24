using System;
using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyLookAtProvider : MonoBehaviour
    {
        [Inject] private readonly EnemyStateManager _stateManager;
        [Inject] private readonly EnemyAttackAssistComponent _rotationComponent;
        [Inject] private PlayerTransform _playerTransform;

        private void Update()
        {
            if (_stateManager.IsBusy)
                _rotationComponent.RotateToTarget();
        }
    }
}