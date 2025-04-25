using System;
using Modules;
using UnityEngine;
using Zenject;
using Transform = log4net.Util.Transform;

namespace Gameplay
{
    public class EnemyLookAtProvider : MonoBehaviour
    {
        [Inject] private readonly EnemyStateManager _stateManager;
        [Inject] private readonly EnemyAttackAssistComponent _rotationComponent;

        private void Update()
        {
            if (_stateManager.IsBusy)
                _rotationComponent.RotateToTarget();
        }
    }
}