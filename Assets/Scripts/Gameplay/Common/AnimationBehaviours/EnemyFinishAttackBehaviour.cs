using UnityEngine;

namespace Gameplay
{
    public class EnemyFinishAttackBehaviour : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<EnemyStateProvider>().FinishAttack();
        }
    }
}