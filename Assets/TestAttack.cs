using Gameplay;
using UnityEngine;
using Zenject;

public class TestAttack : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyStateProvider>().FinishAttack();
    }
}