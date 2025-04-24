using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyAttackAnimationController : ITickable
    {
        private EnemyStateObserver _stateObserver;
        private Animator _animator;

        public EnemyAttackAnimationController(EnemyStateObserver stateObserver, Animator animator)
        {
            _stateObserver = stateObserver;
            _animator = animator;
        }

        public void Tick()
        {
            if (_stateObserver.IsAttacking && !_stateObserver.IsBusy)
            {
                _animator.Play("Attack_01");
                _stateObserver.IsBusy = true;
            }
        }
    }
}