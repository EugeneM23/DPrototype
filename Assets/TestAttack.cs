using Gameplay;
using UnityEngine;
using Zenject;

public class TestAttack : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<SphereDamageCaster>().shouldCast = true;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyStateProvider>().FinishAttack();
        animator.GetComponent<SphereDamageCaster>().shouldCast = false;
    }
}