using System;
using Gameplay.BehComponents;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class AttackComponent
    {
        public event Action OnAttacked;
        
        private readonly EnemyConditions _conditions;
        private readonly NavMeshAgent _agent;
        private readonly RotationToTarget _rotator;
        private readonly Transform _target;

        public AttackComponent(EnemyConditions conditions, RotationToTarget rotator, Player player, NavMeshAgent enemy)
        {
            _conditions = conditions;
            _rotator = rotator;
            _agent = enemy;
            _target = player.GetTransform();
        }

        public void Attack()
        {
            _conditions.IsPatroling = false;
            _conditions.IsChasing = false;
            _agent.isStopped = true;
            
            OnAttacked?.Invoke();

            Debug.Log("rotation");
            _rotator.Rotation(_agent.transform, _target);
        }
    }
}