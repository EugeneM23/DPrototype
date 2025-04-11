using Gameplay;
using UnityEngine;
using Zenject;

public class AttackAnimationBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<AttackAnimationProvider>().StartAttackAnimation();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<AttackAnimationProvider>().FinishAttackAnimation();
    }
}