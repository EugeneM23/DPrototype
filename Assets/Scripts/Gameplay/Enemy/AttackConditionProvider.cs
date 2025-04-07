using UnityEngine;

namespace Gameplay
{
    public class AttackConditionProvider : MonoBehaviour
    {
        [SerializeField] private EnemyStateMachine _stateMachine;

        /*public void FinishAnimation() => _stateMachine.IsOnAnimation = false;

        public void StartAnimation() => _stateMachine.IsOnAnimation = true;*/
    }
}